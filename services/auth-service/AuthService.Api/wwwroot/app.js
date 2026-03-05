const GOOGLE_CLIENT_ID = "916712222503-dsaf27st89vsgv96mn0kio3ius4s31eg.apps.googleusercontent.com";
const API_URL = "https://localhost:7169/api/v1/authentication/signin/google";

window.onload = () => {
    google.accounts.id.initialize({
        client_id: GOOGLE_CLIENT_ID,
        callback: handleGoogleLogin
    });

    google.accounts.id.renderButton(
        document.getElementById("google-btn"),
        {
            theme: "outline",
            size: "large"
        }
    );
};

async function handleGoogleLogin(response) {
    document.getElementById("status").innerText = "Signing in...";

    try {
        const res = await fetch(API_URL, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                idToken: response.credential
            })
        });

        if (!res.ok) {
            throw new Error("Authentication failed");
        }

        const data = await res.json();

        // Store tokens (production: httpOnly cookie preferred)
        localStorage.setItem("accessToken", data.accessToken);
        localStorage.setItem("refreshToken", data.refreshToken);

        document.getElementById("status").innerText = "Login successful ✅";
        document.getElementById("result").innerText = data;
        console.log("Access Token:", data.accessToken);
        console.log("Access Token:", data);

    } catch (err) {
        document.getElementById("status").innerText = "Login failed ❌";
        console.error(err);
    }
}

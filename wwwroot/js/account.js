function toggleForms(event) {
    event.preventDefault();
    const loginForm = document.getElementById("login-form");
    const registerForm = document.getElementById("register-form");
    const formTitle = document.getElementById("form-title");
    const toggleLink = document.getElementById("toggle-link");

    if (loginForm.style.display === "none") {
        // Show login form and hide registration form
        loginForm.style.display = "block";
        registerForm.style.display = "none";
        formTitle.textContent = "Login";
        toggleLink.innerHTML = "Don't have an account? <a href='#' onclick='toggleForms(event);'>Register</a>";
    } else {
        // Show registration form and hide login form
        loginForm.style.display = "none";
        registerForm.style.display = "block";
        formTitle.textContent = "Register";
        toggleLink.innerHTML = "Already have an account? <a href='#' onclick='toggleForms(event);'>Login</a>";
    }
}
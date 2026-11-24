(() => {
    const showMessage = (element, text, isSuccess = false) => {
        element.textContent = text;
        element.classList.toggle('success', isSuccess);
    };

    const loginForm = document.getElementById('loginForm');
    if (loginForm) {
        loginForm.addEventListener('submit', event => {
            event.preventDefault();
            const feedback = document.getElementById('loginFeedback');
            const email = document.getElementById('loginEmail').value.trim().toLowerCase();
            const password = document.getElementById('loginPassword').value;
            if (!loginForm.reportValidity()) return;
            if (email !== 'admin@armsguard.local' || password !== 'GuardDemo!26') {
                showMessage(feedback, 'The demonstration credentials did not match. Please try the credentials shown above.');
                return;
            }
            sessionStorage.setItem('armsguardAdminDemo', 'true');
            showMessage(feedback, 'Demo login successful. Opening the dashboard…', true);
            window.location.assign('/Admin/Dashboard');
        });
    }

    const signupForm = document.getElementById('signupForm');
    if (signupForm) {
        signupForm.addEventListener('submit', event => {
            event.preventDefault();
            const feedback = document.getElementById('signupFeedback');
            if (!signupForm.reportValidity()) return;
            if (document.getElementById('signupPassword').value !== document.getElementById('confirmPassword').value) {
                showMessage(feedback, 'The passwords do not match.');
                return;
            }
            showMessage(feedback, 'Your details passed this client-side demonstration. No account was created or saved.', true);
            signupForm.reset();
        });
    }

    const licensingForm = document.getElementById('licensingForm');
    if (licensingForm) {
        licensingForm.addEventListener('submit', event => {
            event.preventDefault();
            const feedback = document.getElementById('licensingFeedback');
            if (!licensingForm.reportValidity()) return;
            showMessage(feedback, 'Demonstration request validated. Nothing was submitted to an authority or saved.', true);
            licensingForm.reset();
        });
    }
})();

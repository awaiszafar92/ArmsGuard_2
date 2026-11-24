document.querySelectorAll('[data-password-toggle]').forEach(button => button.addEventListener('click', () => {
    const input = document.getElementById(button.dataset.passwordToggle);
    const visible = input.type === 'password';
    input.type = visible ? 'text' : 'password';
    button.textContent = visible ? 'Hide' : 'Show';
    button.setAttribute('aria-label', `${visible ? 'Hide' : 'Show'} password`);
}));

document.querySelectorAll('[data-demo-link]').forEach(link => link.addEventListener('click', event => {
    event.preventDefault();
    window.alert(link.dataset.demoLink);
}));

document.querySelectorAll('[data-enquiry]').forEach(button => button.addEventListener('click', () => {
    window.alert(`Your enquiry about “${button.dataset.enquiry}” is a demonstration request for administrative and legal review only. It was not submitted or saved.`);
}));

const trackingRecords = {
    'AG-2026-1048': ['General information', 'May 18, 2026', 'Submitted', 'This sample request was received for demonstration purposes. No official application was filed.'],
    'AG-2026-1052': ['Sporting use information', 'May 17, 2026', 'Under Review', 'This fictional record demonstrates an under-review status.'],
    'AG-2026-1061': ['Renewal information', 'May 15, 2026', 'Further Information Required', 'This fictional record demonstrates a request for further information.'],
    'AG-2026-1074': ['General information', 'May 12, 2026', 'Approved for Further Processing', 'This fictional status is not a license or approval from a government authority.'],
    'AG-2026-1080': ['Historical item information', 'May 10, 2026', 'Rejected', 'This fictional record demonstrates a rejected status.']
};

const trackingForm = document.getElementById('trackingForm');
if (trackingForm) {
    const showRecord = reference => {
        const record = trackingRecords[reference.trim().toUpperCase()];
        const feedback = document.getElementById('trackingFeedback');
        const result = document.getElementById('trackingResult');
        if (!record) {
            feedback.textContent = 'No demonstration record matches that reference. Use one of the sample reference numbers below.';
            feedback.classList.remove('success');
            result.hidden = true;
            return;
        }
        feedback.textContent = '';
        result.hidden = false;
        document.getElementById('trackingType').textContent = record[0];
        document.getElementById('trackingDate').textContent = record[1];
        document.getElementById('trackingStatus').textContent = record[2];
        document.getElementById('trackingReference').textContent = reference.trim().toUpperCase();
        document.getElementById('trackingDetails').textContent = record[3];
    };
    trackingForm.addEventListener('submit', event => {
        event.preventDefault();
        if (!trackingForm.reportValidity()) return;
        showRecord(document.getElementById('referenceNumber').value);
    });
    document.querySelectorAll('[data-reference]').forEach(button => button.addEventListener('click', () => {
        document.getElementById('referenceNumber').value = button.dataset.reference;
        showRecord(button.dataset.reference);
    }));
}

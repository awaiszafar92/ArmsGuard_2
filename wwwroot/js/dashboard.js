(() => {
    if (!document.body.classList.contains('admin-body')) return;
    const accessMessage = document.getElementById('adminAccessMessage');
    if (sessionStorage.getItem('armsguardAdminDemo') !== 'true') {
        accessMessage.hidden = false;
        document.querySelectorAll('.admin-content > section').forEach(section => section.hidden = true);
        window.setTimeout(() => window.location.replace('/Account/Login'), 1800);
        return;
    }

    document.querySelectorAll('[data-admin-logout]').forEach(button => button.addEventListener('click', () => {
        sessionStorage.removeItem('armsguardAdminDemo');
        window.location.assign('/Account/Login');
    }));

    document.querySelectorAll('.admin-nav a[href^="#"]').forEach(link => link.addEventListener('click', () => {
        document.querySelectorAll('.admin-nav a').forEach(item => item.classList.remove('active'));
        link.classList.add('active');
    }));

    document.querySelectorAll('[data-table-search]').forEach(input => input.addEventListener('input', () => {
        const table = document.getElementById(input.dataset.tableSearch);
        const term = input.value.toLowerCase();
        table.querySelectorAll('tbody tr').forEach(row => row.hidden = !row.textContent.toLowerCase().includes(term));
    }));

    const modal = document.getElementById('recordModal');
    document.querySelectorAll('[data-view-record]').forEach(button => button.addEventListener('click', () => {
        document.getElementById('recordModalTitle').textContent = `Sample record ${button.dataset.viewRecord}`;
        document.getElementById('recordModalBody').textContent = button.dataset.details;
        bootstrap.Modal.getOrCreateInstance(modal).show();
    }));

    document.querySelectorAll('.status-select').forEach(select => select.addEventListener('change', () => {
        const feedback = document.getElementById('adminFeedback');
        feedback.textContent = `Sample status changed to “${select.value}” for this page session only.`;
        feedback.classList.add('success');
    }));

    document.querySelectorAll('[data-catalog-action]').forEach(button => button.addEventListener('click', () => window.alert(`“${button.dataset.catalogAction}” is sample catalog data. Editing is not saved in this demonstration.`)));
    document.querySelectorAll('[data-user-action]').forEach(button => button.addEventListener('click', () => window.alert(`${button.dataset.userAction} is a fictional sample user. No account record is available.`)));
})();

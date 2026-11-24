(() => {
    const catalogSearch = document.getElementById('catalogSearch');
    const catalogCategory = document.getElementById('categoryFilter');
    const manufacturer = document.getElementById('manufacturerFilter');
    const marketSearch = document.getElementById('marketSearch');
    const marketCategory = document.getElementById('marketCategory');

    const filter = (items, search, category, extraFilter, empty, count) => {
        if (!items.length) return;
        const term = (search?.value || '').trim().toLowerCase();
        const selectedCategory = category?.value || '';
        const selectedExtra = extraFilter?.value || '';
        let visible = 0;
        items.forEach(item => {
            const matches = (!term || `${item.dataset.name || ''} ${item.dataset.search || ''} ${item.dataset.manufacturer || ''} ${item.textContent}`.toLowerCase().includes(term))
                && (!selectedCategory || item.dataset.category === selectedCategory)
                && (!selectedExtra || item.dataset.manufacturer === selectedExtra);
            item.classList.toggle('d-none', !matches);
            if (matches) visible++;
        });
        if (empty) empty.classList.toggle('d-none', visible !== 0);
        if (count) count.textContent = `${visible} sample record${visible === 1 ? '' : 's'} shown`;
    };

    const catalogItems = [...document.querySelectorAll('.catalog-item')];
    [catalogSearch, catalogCategory, manufacturer].filter(Boolean).forEach(control => control.addEventListener('input', () => filter(catalogItems, catalogSearch, catalogCategory, manufacturer, document.getElementById('catalogEmpty'), document.getElementById('catalogCount'))));
    if (catalogItems.length) filter(catalogItems, catalogSearch, catalogCategory, manufacturer, document.getElementById('catalogEmpty'), document.getElementById('catalogCount'));

    const marketItems = [...document.querySelectorAll('.market-item')];
    [marketSearch, marketCategory].filter(Boolean).forEach(control => control.addEventListener('input', () => filter(marketItems, marketSearch, marketCategory, null, document.getElementById('marketEmpty'), null)));
    if (marketItems.length) filter(marketItems, marketSearch, marketCategory, null, document.getElementById('marketEmpty'), null);
})();

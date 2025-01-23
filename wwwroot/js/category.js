document.getElementById('iconSelect')?.addEventListener('change', function() {
    const preview = document.getElementById('iconPreview');
    if (preview) {
        preview.className = this.value;
    }
});
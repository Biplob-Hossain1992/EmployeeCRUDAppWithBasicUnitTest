var baseURL = "https://localhost:44326";
$('.datepicker').daterangepicker({
    "locale": {
        "format": "DD MMM YYYY",
    },
    singleDatePicker: true,
    showDropdowns: true,
    autoUpdateInput: true,
});
$(".select2Body").select2({
    width: '100%', placeholder: "Select..",
    allowClear: true,
});
$('.select2Modal').each(function (i, obj) {
    $(this).select2({
        dropdownParent: $(this).closest("div.modal"), width: '100%', placeholder: "Select..",
        allowClear: true,
    });
});

$(document).ready(function () {
    $('#carTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        // Qo'shimcha parametrlar...
    });
    $('.select2').select2();
});

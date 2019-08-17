$(function () {
    $("#tblDepartments").DataTable()
    $("#tblPersonnels").DataTable()
    $("#tblUsers").DataTable()
    $("#tblDepartments").on("click", ".btnDeleteDepartment", function () {
        var id = $(this).data("id")
        var name = $(this).data("name") + " Department"
        var btn = $(this)
        bootbox.confirm(name.bold().italics() + " will be deleted! Are you sure?", function (result) {
            if (result) {
                $.ajax({
                    type: "GET",
                    url: "Department/Delete/" + id,
                    success: function () {
                        btn.parent().parent().remove()
                    }

                })
            }
        })
    })

})

function CheckDateTypeIsValid(dateElement) {
    var value = $(dateElement).val();
    if (value == '') {
        $(dateElement).valid("false");
    }

    else {
        $(dateElement).valid();
    }
}
$(function () {
    $("#tblDepartments").DataTable()
    $("#tblPersonnels").DataTable()
    $("#tblUsers").DataTable()
    $("#tblShowPersonnelsInDepartment").DataTable()

    $("#tblDepartments").on("click", ".linkDelActDepartment", function () {
        var id = $(this).data("id")
        var name = $(this).data("name") + " Department"
        var linkDelAct = $(this)
        bootbox.confirm(name.bold().italics() + " will be " + linkDelAct.text().toLowerCase() + "d! Are you sure?", function (result) {
            if (result) {
                $.ajax({
                    type: "GET",
                    url: "Department/DeleteOrActivate/" + id,
                    success: function () {
                        var text_delAct = (linkDelAct.text() == "Delete") ? "Activate" : "Delete"
                        linkDelAct.text(text_delAct)
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
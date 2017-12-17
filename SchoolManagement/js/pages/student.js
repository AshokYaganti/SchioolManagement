$(function () {

    $('#searchedcourses').dataTable();
    $('#enrolledcourses').dataTable();
    $('#payhistory').dataTable();

    $(".dropcls").click(function (e2) {
        e2.preventDefault();
        var enrollmentid = $(this).closest("tr").find('td:eq(0)').text();
        var courseid = $(this).closest("tr").find('td:eq(1)').text();
       
        $('#eid').val(enrollmentid);
        $('#cid').val(courseid);

    });


    $("#dropCourse").click(function () {

        var eid = $("#eid").val();
        var cid = $("#cid").val();

        $.ajax({
            type: "POST",
            url: "EnrolledCourses.aspx/dropCourse",
            data: "{ eid:\"" + eid + "\" , cid:\"" + cid + "\" }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == "success") {
                    $("#dropCourse").remove();
                    $("#dropModal .modal-body").html("Course has been dropped");
                    $('#dropclosebtn').click(function () { location.reload(); });
                    $('#dropclosebtn2').click(function () { location.reload(); });
                } else {
                    $("#dropCourse").remove();
                    $("#dropModal .modal-body").html("Something went wrong with this request.Please try again later");
                }
            },
            error: function () {
                $("#dropCourse").remove();
                $("#dropModal .modal-body").html("Something went wrong with this request.Please try again later");
            }

        });


    });

});
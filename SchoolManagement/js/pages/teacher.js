$(function () {

    $('#assignedCourses').dataTable();
    $('#studentenrollments').dataTable();
    $('#searchedcourses').dataTable();
    $('#enrolledStudents').dataTable();

    $(".addgrade").click(function (e3) {
        e3.preventDefault();
        $("#eid").val($(this).data("eid"));
    });


    $("#addGradeBtn").click(function () {

        var eid = $("#eid").val();
        var grade = $("#grade").val();        
       
            $.ajax({
                type: "POST",
                url: "AddGrade.aspx/assignStudentGrade",
                data: "{ eid:\"" + eid + "\",grade:\"" + grade + "\"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == "success") {
                        $("#addGradeBtn").remove();
                        $("#addModal .modal-body").html("Grde has been assigned to student");
                        $('#addgradeclose').click(function () { location.reload(); });
                        $('#addgradeclose2').click(function () { location.reload(); });
                    } else {
                        $("#addGradeBtn").remove();
                        $("#addModal .modal-body").html("Something went wrong with this request.Please try again later");
                    }
                },
                error: function () {
                    $("#addGradeBtn").remove();
                    $("#addModal .modal-body").html("Something went wrong with this request.Please try again later");
                }

            });       

    });


});
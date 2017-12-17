$(function () {

    $('#sdate').datepicker('option', 'minDate', '0');
    var startdate = $("#sdate").val();
    $('#edate').datepicker('option', 'minDate', startdate);
    $('#termstable').dataTable();
    $('#teachertable').dataTable();
    $('#assignTeachers').dataTable();
    $('#studentpayments').dataTable();
    $('#studentApplications').dataTable({
        responsive: true,
        "columns": [ 
          null,
		  null,
		  null,
		  null,
		  null,
		  null,
          null,
		 { "orderable": false, className:"none" },
		 { "orderable": false, className:"none" },
         { "orderable": false, className:"none" },
		 { "orderable": false, className:"none" },
		 { "orderable": false, className:"none" },
		 null,
         null
    ],
    });

    $("#addTeacher").click(function () {

        var tname = $("#tname").val();
        var email = $("#email").val();
        var schoolid = $("#schoolidtxt").val();

        if (tname.length == 0) {
            $("#namevalidation").removeClass("hidden");
            $("#emailvalidation").addClass("hidden");
        } else if (email.length == 0) {
            $("#emailvalidation").removeClass("hidden");
            $("#namevalidation").addClass("hidden");
        } else {
            $("#namevalidation").addClass("hidden");
            $("#emailvalidation").addClass("hidden");
            $.ajax({
                type: "POST",
                url: "Teachers.aspx/addTeacher",
                data: "{ tname:\"" + tname + "\",email:\"" + email + "\", schoolid:\"" + schoolid + "\" }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == "success") {
                        $("#addTeacher").remove();
                        $("#addModal .modal-body").html("Teacher record has been created");
                        $('#closebtn').click(function () { location.reload(); });
                        $('#closebtn2').click(function () { location.reload(); });
                    } else {
                        $("#addTeacher").remove();
                        $("#addModal .modal-body").html("Something went wrong with this request.Please try again later");
                    }
                },
                error: function () {
                    $("#addTeacher").remove();
                    $("#addModal .modal-body").html("Something went wrong with this request.Please try again later");
                }

            });
        }

    });


    $(".updatecls").click(function (e2) {
        e2.preventDefault();
        var teacherid = $(this).closest("tr").find('td:eq(0)').text();
        var tname = $(this).closest("tr").find('td:eq(1)').text();
        var email = $(this).closest("tr").find('td:eq(2)').text();

        $('#teacherid').val(teacherid);
        $('#tname1').val(tname);
        $('#email1').val(email);

    });


    $(".deletecls").click(function (e3) {
        e3.preventDefault();
        var teacherid = $(this).closest("tr").find('td:eq(0)').text();

        $('#teacherid1').val(teacherid);

    });

    $(".approvecls").click(function (e4) {
        e4.preventDefault();
        var applicationid = $(this).closest("tr").find('td:eq(0)').text();
        var email = $(this).closest("tr").find('td:eq(6)').text();        
        $('#applicationid').val(applicationid);
        $('#email').val(email);

    });

    $(".rejectcls").click(function (e5) {
        e5.preventDefault();
        var applicationid = $(this).closest("tr").find('td:eq(0)').text();
        var email = $(this).closest("tr").find('td:eq(6)').text();
         $('#applicationid1').val(applicationid);
        $('#email1').val(email);

    });


    $(".courseupdatecls").click(function (e2) {
        e2.preventDefault();
        var courseid = $(this).closest("tr").find('td:eq(0)').text();
        var cname = $(this).closest("tr").find('td:eq(1)').text();
        var seats = $(this).closest("tr").find('td:eq(3)').text();
        var cost = $(this).closest("tr").find('td:eq(5)').text();

        $('#courseid').val(courseid);
        $('#cname1').val(cname);
        $('#seats1').val(seats);
        $('#cost1').val(cost);

    });


    $(".coursedeleteecls").click(function (e3) {
        e3.preventDefault();
        var courseid = $(this).closest("tr").find('td:eq(0)').text();

        $('#courseid1').val(courseid);

    });



    $("#updateTeacher").click(function () {

        var tname = $("#tname1").val();
        var email = $("#email1").val();
        var teacherid = $("#teacherid").val();
        var schoolid = $("#schoolidtxt").val();

        if (tname.length == 0) {
            $("#namevalidation1").removeClass("hidden");
            $("#emailvalidation1").addClass("hidden");
        } else if (email.length == 0) {
            $("#emailvalidation1").removeClass("hidden");
            $("#namevalidation1").addClass("hidden");
        } else {
            $("#namevalidation1").addClass("hidden");
            $("#emailvalidation1").addClass("hidden");
            $.ajax({
                type: "POST",
                url: "Teachers.aspx/updateTeacher",
                data: "{ tname:\"" + tname + "\",email:\"" + email + "\", schoolid:\"" + schoolid + "\" , teacherid:\"" + teacherid + "\" }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == "success") {
                        $("#updateTeacher").remove();
                        $("#updateModel .modal-body").html("Teacher record has been updated");
                        $('#updateclosebtn').click(function () { location.reload(); });
                        $('#updateclosebtn2').click(function () { location.reload(); });
                    } else {
                        $("#updateTeacher").remove();
                        $("#updateModel .modal-body").html("Something went wrong with this request.Please try again later");
                    }
                },
                error: function () {
                    $("#updateTeacher").remove();
                    $("#updateModel .modal-body").html("Something went wrong with this request.Please try again later");
                }

            });
        }

    });


    $("#deleteTeacher").click(function () {

        var teacherid = $("#teacherid1").val();
        var schoolid = $("#schoolidtxt").val();

        $.ajax({
            type: "POST",
            url: "Teachers.aspx/deleteTeacher",
            data: "{ schoolid:\"" + schoolid + "\" , teacherid:\"" + teacherid + "\" }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == "success") {
                    $("#deleteTeacher").remove();
                    $("#deleteModal .modal-body").html("Teacher record has been deleted");
                    $('#deleteclosebtn').click(function () { location.reload(); });
                    $('#deleteclosebtn2').click(function () { location.reload(); });
                } else {
                    $("#deleteTeacher").remove();
                    $("#deleteModal .modal-body").html("Something went wrong with this request.Please try again later");
                }
            },
            error: function () {
                $("#deleteTeacher").remove();
                $("#deleteModal .modal-body").html("Something went wrong with this request.Please try again later");
            }

        });


    });


    $("#addCourse").click(function () {

        var cname = $("#cname").val();
        var seats = $("#seats").val();
        var cost = $("#cost").val();
        var schoolid = $("#schoolidtxt").val();
        var term = $("#DropDownList1 option:selected").val();

        if (cname.length == 0) {
            $("#cnamevalidation").removeClass("hidden");
            $("#seatsvalidation").addClass("hidden");
            $("#costvalidation").addClass("hidden");
        } else if (seats.length == 0) {
            $("#seatsvalidation").removeClass("hidden");
            $("#cnamevalidation").addClass("hidden");
            $("#costvalidation").addClass("hidden");
        } else if (cost.length == 0) {
            $("#seatsvalidation").addClass("hidden");
            $("#cnamevalidation").addClass("hidden");
            $("#costvalidation").removeClass("hidden");
        } else {
            $("#cnamevalidation").addClass("hidden");
            $("#seatsvalidation").addClass("hidden");
            $("#costvalidation").addClass("hidden");
            $.ajax({
                type: "POST",
                url: "Courses.aspx/addCourse",
                data: "{ cname:\"" + cname + "\",term:\"" + term + "\" , seats:\"" + seats + "\",cost:\"" + cost + "\", schoolid:\"" + schoolid + "\" }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == "success") {
                        $("#addCourse").remove();
                        $("#addCourseModal .modal-body").html("Course record has been created");
                        $('#courseclosebtn').click(function () { location.reload(); });
                        $('#courseclosebtn2').click(function () { location.reload(); });
                    } else {
                        $("#addCourse").remove();
                        $("#addCourseModal .modal-body").html("Something went wrong with this request.Please try again later");
                    }
                },
                error: function () {
                    $("#addCourse").remove();
                    $("#addCourseModal .modal-body").html("Something went wrong with this request.Please try again later");
                }

            });
        }

    });


    $("#updateCourse").click(function () {

        var cname = $("#cname1").val();
        var seats = $("#seats1").val();
        var cost = $("#cost1").val();
        var courseid = $("#courseid").val();

        if (cname.length == 0) {
            $("#cnamevalidation1").removeClass("hidden");
            $("#seatsvalidation1").addClass("hidden");
            $("#costvalidation1").addClass("hidden");
        } else if (seats.length == 0) {
            $("#seatsvalidation1").removeClass("hidden");
            $("#cnamevalidation1").addClass("hidden");
            $("#costvalidation1").addClass("hidden");
        } else if (cost.length == 0) {
            $("#seatsvalidation1").addClass("hidden");
            $("#cnamevalidation1").addClass("hidden");
            $("#costvalidation1").removeClass("hidden");
        } else {
            $("#cnamevalidation1").addClass("hidden");
            $("#seatsvalidation1").addClass("hidden");
            $("#costvalidation1").addClass("hidden");
            $.ajax({
                type: "POST",
                url: "Courses.aspx/updateCourse",
                data: "{ cname:\"" + cname + "\", seats:\"" + seats + "\",cost:\"" + cost + "\", courseid:\"" + courseid + "\" }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == "success") {
                        $("#updateCourse").remove();
                        $("#courseupdateModel .modal-body").html("Course record has been updated");
                        $('#updateCourseclosebtn').click(function () { location.reload(); });
                        $('#updateCourseclosebtn2').click(function () { location.reload(); });
                    } else {
                        $("#updateCourse").remove();
                        $("#courseupdateModel .modal-body").html("Something went wrong with this request.Please try again later");
                    }
                },
                error: function () {
                    $("#updateCourse").remove();
                    $("#courseupdateModel .modal-body").html("Something went wrong with this request.Please try again later");
                }

            });
        }

    });

    $("#deleteCourse").click(function () {

        var courseid = $("#courseid1").val();

        $.ajax({
            type: "POST",
            url: "Courses.aspx/deleteCourse",
            data: "{ courseid:\"" + courseid + "\" }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == "success") {
                    $("#deleteCourse").remove();
                    $("#coursedeleteModal .modal-body").html("Course record has been deleted");
                    $('#deleteCourseclosebtn').click(function () { location.reload(); });
                    $('#deleteCourseclosebtn2').click(function () { location.reload(); });
                } else {
                    $("#deleteCourse").remove();
                    $("#coursedeleteModal .modal-body").html("Something went wrong with this request.Please try again later");
                }
            },
            error: function () {
                $("#deleteCourse").remove();
                $("#coursedeleteModal .modal-body").html("Something went wrong with this request.Please try again later");
            }

        });
    });


    $("#approvebtn").click(function () {

        var applicationid = $("#applicationid").val();
        var email = $("#email").val();

        $.ajax({
            type: "POST",
            url: "DirectorHome.aspx/approveApplication",
            data: "{ applicationid:\"" + applicationid + "\" , email:\"" + email + "\" }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == "success") {
                    $("#approvebtn").remove();
                    $("#approveModal .modal-body").html("Student application has been approved");
                    $('#approveclosebtn').click(function () { location.reload(); });
                    $('#approveclosebtn2').click(function () { location.reload(); });
                } else {
                    $("#approvebtn").remove();
                    $("#approveModal .modal-body").html("Something went wrong with this request.Please try again later");
                }
            },
            error: function () {
                $("#approvebtn").remove();
                $("#approveModal .modal-body").html("Something went wrong with this request.Please try again later");
            }

        });
    });


    $("#rejectbtn").click(function () {

        var applicationid = $("#applicationid1").val();
        var email = $("#email1").val();

        $.ajax({
            type: "POST",
            url: "DirectorHome.aspx/rejectApplication",
            data: "{ applicationid:\"" + applicationid + "\" , email:\"" + email + "\" }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == "success") {
                    $("#rejectbtn").remove();
                    $("#rejectModal .modal-body").html("Student application has been rejected");
                    $('#rejectclosebtn').click(function () { location.reload(); });
                    $('#rejectclosebtn2').click(function () { location.reload(); });
                } else {
                    $("#rejectbtn").remove();
                    $("#rejectModal .modal-body").html("Something went wrong with this request.Please try again later");
                }
            },
            error: function () {
                $("#rejectbtn").remove();
                $("#rejectModal .modal-body").html("Something went wrong with this request.Please try again later");
            }

        });
    });


});
$(function () {


    $("#addComment").click(function () {
        const pid = $("#PostId").val();
        const uid = $("#UserId").val();
        const c = $("#Comment").val();
        $.ajax({
            method: "POST",
            url: "/post/addcomment",
            data: {
                PostId: pid,
                UserId: uid,
                Comment: c
            }
        }).done(function (done) {
            swal({
                icon: done.icon,
                title: done.title,
                text: done.text,
                button: "Kapat"
            })
        }).fail(function (fail) {
            console.log(fail)
            alert(fail);
        }).always(function () {
            $("#Comment").val(null);
        })
    })
})
$(function () {
    $(".comment-list").click(function (e) {
        if (e.target.classList.contains("btn-reply")) {
            let replyArea = $(".reply-area")
            if (replyArea != null) {
                replyArea.remove()
            }
            let html = `
            <div class="reply-area row row-cols-1 gx-0 bg-light p-2">
                <div class="col text-end">
                    <button type="button" class="btn btn-danger btn-sm btn-reply-remove"><i class="fa-solid fa-xmark"></i></button>
                </div>
                <div class="col my-2">
                    <textarea id="Reply" name="Reply" rows="5" class="form-control" placeholder="Cevabınız..."></textarea>
                </div>
                <div class="col">
                    <button id="addReply" type="button" class="btn btn-primary btn-sm">Gönder</button>
                </div>
            </div>
            `;
            e.target.parentElement.lastElementChild.innerHTML += html;
        }
        if (e.target.classList.contains("btn-reply-remove") || e.target.classList.contains("fa-xmark")) {
            $(".reply-area").remove()
        }
        if (e.target.id == "addReply") {
            const uid = $("#commentForm").find("#UserId").val();
            const cid = $(e.target).parents("#replyForm").children("#CommentId").val();
            const r = $("#Reply").val();

            $.ajax({
                method: "POST",
                url: "/post/addreply",
                data: {
                    UserId: uid,
                    CommentId: cid,
                    Reply: r
                }
            }).done(function (done) {
                swal({
                    icon: done.icon,
                    title: done.title,
                    text: done.text,
                    button: "Kapat"
                })
            }).fail(function (fail) {
                alert(fail);
            }).always(function () {
                $("#Reply").val(null);
            })
        }
    })
})
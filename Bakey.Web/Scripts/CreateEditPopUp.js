$(document).ready(function () {
    $(".editBtn").click(function (e) {
        e.preventDefault();
        $("#productContent").load(this.href);
        $("#productModal").modal("show");
    });

    Product.sendAjax("#editForm");


    $(".createBtn").click(function (e) {
        e.preventDefault();
        $("#productContent").load(this.href);
        $("#productModal").modal("show");
    });

    Product.sendAjax("#createForm");


});


Product = {
    sendAjax: function (formName) {
        $(document).on("submit", formName, function (e) {
            e.preventDefault();

            var form = $(formName);
            var formdata = false;
            if (window.FormData)
                formdata = new FormData(form[0]);

            $.ajax({
                url: form.attr("action"),
                type: 'POST',
                data: formdata ? formdata : form.serialize(),
                cache: false,
                contentType: false,                             // empty Header Content-Type
                processData: false,                              // not convert to string
                success: function (output) {
                    if (output.length > 30)
                        $("#productContent").html(output);
                    else
                        document.location.href = output;
                }

            });
        });
    }
}
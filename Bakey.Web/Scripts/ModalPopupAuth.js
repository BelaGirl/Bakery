        $(document).ready(function () {

            $.ajaxSetup({ cache: false });

            $("#loginLink").click(function(e){
                e.preventDefault();              

                $(".modal-body").load(this.href);
                
                $("#loginModal").modal("show");
            
            });
             
            // отправка формы ajax
            $(document).on("submit", "#formLogin", function (e) {
                e.preventDefault();

                var form = $("#formLogin");
                $.ajax({
                    url: form.attr("action"),
                    method: "POST",
                    data: form.serialize(),
                    dataType: "html",
                    // получение данных от сервера
                    success: function (html) {
                        if (!html.length==0)                // чтобы не отображался location.href
                            $(".modal-body").html(html);
                        else 
                        {
                            document.location.href=html;
                        }
                    }
                });         
            });

            // it will also work for the DOM added later.
            $(document).on("click", "#registerLink", (function (e) {
                e.preventDefault();

                $(".modal-body").load(this.href);
                $("#loginModal").modal("show");
            }));


            $(document).on("submit", "#formRegister", function (e) {
                e.preventDefault();

                var form = $("#formRegister");
                $.ajax({
                    url: form.attr("action"),
                    method: "POST",
                    data: form.serialize(),
                    dataType: "html script",
                    // получение данных от сервера
                    success: function (html) {
                        if (!html.length == 0)
                            $(".modal-body").html(html);
                        else {
                            $(".modal-body").load("/Account/Login");
                            $("#loginModal").modal("show");
                        }

                       
                    }
                });
            });

        });


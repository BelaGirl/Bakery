$(document).ready(function () {

    $(".getBtn").click(function (e) {
        e.preventDefault();
        var id = $(this).attr("catId");
        Products.getProducts(id);
    });

    $(".createBtn").click(function (e) {
        e.preventDefault();
        $("#NameValidation").empty();
        $("#PriceValidation").empty();
        $("#SummaryValidation").empty();

        $("#productCreateModal").modal("show");
    });

    $(document).on("click", "#sendAdd", function (e) {
        e.preventDefault();       

        Products.addProduct();
    });

    $(document).on("click", ".deleteBtn", function (e) {
        e.preventDefault();
        var id = $(this).attr("prodId");
        Products.deleteProduct(id);
    });


    $(document).on("click", ".editBtn", function (e) {
        e.preventDefault();
        var id = $(this).attr("prodId");
        Products.getProductForEdit(id);     
     
    });


    $(document).on("click", "#sendEdit", function (e) {
        e.preventDefault();

        $("#NameEditValidation").empty();
        $("#PriceEditValidation").empty();
        $("#SummaryEditValidation").empty();

        Products.updateProduct();
    });

});



Products= {
    prods: [],


    getProducts: function (id) {
        $.ajax({
            type: "GET",
            url: "/api/admin/getProductsByCategory/" + id,
            async: true,
            cache: false,
            success: function (output) {
                Products.prods = output;
                Products.renderProducts();
            }
        });
    },

    addProduct: function () {

        var form = $("#createForm");
        var formdata = false;
        if (window.FormData)
            formdata = new FormData(form[0]);      

        var id = $(".editBtn:first").attr("prodCatId");    // =catId

        $.ajax({
            type: "POST",
            url: "/api/admin/"+id,
            async: true,
            cache: false,
            enctype: 'multipart/form-data',
            processData: false,  
            contentType: false ,          
            data: formdata ? formdata : form.serialize(),
            success: function (output) {
                $("#productCreateModal").modal("hide");
                Products.getProducts(id);
            }          

        });


    },


    deleteProduct: function (id) {

        $.ajax({
            type: "DELETE",
            async: true,
            url: "/api/admin/" + id,
            success: function (output) {
                $.each(Products.prods, function (index) {
                    if (this.Id == id)
                        Products.prods.splice(index, 1);
                });

                Products.renderProducts();
            }

        });
    },


    updateProduct: function () {
        var form = $("#editForm");

        $.ajax({
            type: "PUT",
            url: "/api/admin",
            async: true,
            data: form.serialize(),
            success: function (output) {
                $("#productEditModal").modal("hide");
                var id = $("#editForm input[name='catId']").val();
                Products.getProducts(id);
            },

            error: function (jqXHR, status, error) {
                var response = JSON.parse(jqXHR.responseText);
                $("#SummaryEditValidation").text(response['Message']);

                if (response['ModelState']['prod.Name'] != null)
                    $("#NameEditValidation").text(response['ModelState']['prod.Name']);

                if (response['ModelState']['prod.Price'] != null)
                    $("#PriceEditValidation").text(response['ModelState']['prod.Price']);
            }
        });
    },


    getProductForEdit: function (id) {
        $.ajax({
            type: "GET",
            url: "/api/admin/getproduct/" + id,
            success: function (output) {
                $("#editForm").empty();
                $("#EditTemplate").tmpl(output).appendTo("#editForm");
                $("#productEditModal").modal("show");
            }
        });
    },




    renderProducts: function () {
        $(".productContainer").empty();
        $("#productTemplate").tmpl(Products.prods).appendTo(".productContainer");

    }


}
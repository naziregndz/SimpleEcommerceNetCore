function addProduct(productName, productCount) {

    var data = {
        prop1: productName,
        prop2: productCount
    }

    $.ajax({
        type: "POST",
        url: "/Home/Example",
        data: data,
        dataType: "JSON", //Ajax isteği eğer data dönecek ise; datanın tipi (json/xml/text)
        success: function (result) {
            alert(result);
        },
        error: function () {
            alert('error!');
        }
    });
}

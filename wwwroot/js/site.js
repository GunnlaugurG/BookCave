// Write your JavaScript code.
console.log("Javascript up and running");

$(function() {
    // Setup drop down menu
    $('.dropdown-toggle').dropdown();
   
    // Fix input element click problem
    $('.dropdown input, .dropdown label').click(function(e) {
      e.stopPropagation();
    });
  });
/*
$("#clickMe").click(function(){
    data = 2;
    $.get("TopTenBooks", function(data, status){
        
    });
});*/
/*
$("#get-concerts").click(function(){
    $.get("http://apis.is/concerts", function(data, status){
        $("#conserts").append("<table class=" + "table" +" id="+ "consert-table" + "><tr><th>Event name</th><th>Place</th><th>Date</th></tr></table");
        for(var i = 0; i < data.results.length; i++){
            var markup = "<tr><td>" + data.results[i].eventDateName + "</td><td>" + data.results[i].eventHallName + "</td><td>" + data.results[i].dateOfShow + "</td></tr>";
            console.log(markup);
            $("#consert-table").append(markup);
        }
    });
});
*/
$(function () {
    $("#clickMe").on("click", function () {
    var id = $(this).attr("id");
        $.ajax({
            type: "GET",
            url: "TopTenBooks(2)",
            data: {"type" : id},
            success: function (responseData) {
                $("#list").replaceWith($(responseData).find("#list"));
            }
        });
    return false;
    });
});



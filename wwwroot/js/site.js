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

$("#hehe").click(function(){
    $.get("Book/TopTenBooks", function(data, status){
        console.log("WORKING");
    });
});

$("#secret-student").click(function(){
  $.get("Home/GetSecretStudent", function(data, status){
      $("#tafla").append("<tr><td>" + data.name + "</td> <td>"+ data.age + "</td></tr>");
      $("#secret-student").attr("disabled","disabled");
  });
});



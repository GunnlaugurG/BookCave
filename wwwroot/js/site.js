﻿// Write your JavaScript code.
console.log("Javascript up and running");

$(function() {
    // Setup drop down menu
    $('.dropdown-toggle').dropdown();
   
    // Fix input element click problem
    $('.dropdown input, .dropdown label').click(function(e) {
      e.stopPropagation();
    });
  });




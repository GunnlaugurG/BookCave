﻿// Write your JavaScript code.
$(document).ready(function(){

console.log("Javascript up and running1");

//Ajax request for sorting the book list "All Books"
$("#selectBox").change(function(){
    var sortVal = $(this).val();
    console.log(sortVal);
    var markup = "";
    $.get("/book/SortBy", { value: sortVal }, function(data){
      $('#book-list').fadeOut(1000, function() {
      $('#book-list').empty();});
      $('#book-list').fadeIn(500, function() {
      
          $.each(data,function(i,j){
              markup += '<div id="animate-list" class="col-lg-3 col-sm-6 col-md-4" style="display: none;">'
                     + '<div class="row"> <div class="col-lg-12 col-sm-12">'
                     + '<a href="/book/details/' + j.id + '">'
                     + '<img class="Thumb-nail-image" src="' + j.image + '"alt="book-cover" /></a>'
                     + '</div> </div> <div class="row"> <div id="book-info" class="col-lg-12 col-sm-12">'
                     + '<a href="/book/details/' + j.id + ' class="card-text">' + j.title + '</a>'
                     + '<div class="divider"></div><a href="author/details/' + j.id + '<p>' + j.author.authorName + '</p></a>';
                     for(i = 0; i < j.rating; i++) {
                      markup += '<img src="/Images/fullStar.png" alt="rating" class="starRatings">'
                      }
                      if(j.rating % 1 != 0) {
                          markup += '<img src="/Images/halfStar.png" alt="rating" class="starRatings">'
                      } else {
                          markup += '<img src="/Images/fullStar.png" alt="rating" class="starRatings">'
                      }
                      markup += '<p>Price: ' + j.cost + '</p></div> </div><div class="row">'
                     + '<div class="col-lg-12 col-sm-12 img-thumbnail-btn"><a class="btn btn-default center-block" href="/account/addToCart/'
                     + j.id + '">Add to cart</a></div> </div><div class="row">'
                     + '<div class="col-lg-12 col-sm-4 spacing"></div></div></div>';
                      
                     $(markup).appendTo("#book-list").slideDown(1000);
                     markup = "";
                     console.log(markup);
                    });
                    ;});
                  });
    });

//Fyrir review síðuna
$('#review-form').addClass("hidden");

$('#write-review').click(function(){
  $('#review-form').removeClass("hidden");
});
$('#submit').click(function(){
  
  $('#review-form').addClass("hidden");
  var description = $('#description').val();
  var ratings = $('#ratings').val();
  var bookId = $('#book-id').text();
  $.post("/book/review", 
  {
    bookId: bookId,
    Description: description,
    Ratings: ratings
  }, 
  function(data, status){
    console.log(data);
  })
});

$("#back-to-top").click(function () {

  $("html, body").animate({scrollTop: 0}, 500);
});

$(window).scroll(function() {
  if($(this).scrollTop()>1000) {
      $('#back-to-top').fadeIn();
   } 
   else {
    $('#back-to-top').fadeOut();
   }
});
/// veit ekki hvað þetta er enn þetta kastar villu
//$(function() {
    // Setup drop down menu
  //  $('.dropdown-toggle').dropdown();

    // Fix input element click problem
//    $('.dropdown input, .dropdown label').click(function(e) {
  //    e.stopPropagation();
  //  });
//  });
//Geyma
/*
  $("#SubmitShipping").click(function(event){
    event.preventDefault();
    $.post('/Account/ChangeShippingDetails', $('firstForm').serialize(), function(data) {
        alert("Yes");
    }).fail(function(data) {
        alert("hi");
    })
  });*/
});
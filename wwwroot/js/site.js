// Write your JavaScript code.
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
      $('#book-list').fadeIn(200, function() {
      
          $.each(data,function(i,j){
              markup += '<div id="animate-list" class="col-lg-3 col-sm-6 col-md-4" style="display: none;">'
                     + '<div class="row"> <div class="col-lg-12 col-sm-12">'
                     + '<a href="/book/details/' + j.id + '">'
                     + '<img class="Thumb-nail-image" src="' + j.image + '"alt="book-cover" /></a>'
                     + '</div> </div> <div class="row"> <div id="book-info" class="col-lg-12 col-sm-12">'
                     + '<a href="/book/details/' + j.id + ' class="card-text">' + j.title + '</a> <br/><div class="divider"></div>'
                     + '<a href="/author/details/' + j.author.id + '"class=card-text">' + j.author.authorName + '</a> <br/>'
                     for(i = 0; i < j.rating-1; i++) {
                      markup += '<img src="/Images/fullStar.png" alt="rating" class="starRatings">'
                      }
                      if(j.rating % 1 != 0) {
                          markup += '<img src="/Images/halfStar.png" alt="rating" class="starRatings">'
                      } else {
                          markup += '<img src="/Images/fullStar.png" alt="rating" class="starRatings">'
                      }
                      markup += '<p></a>' + j.cost + ' $</p></div> </div><div class="row">'
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


///////////////Fyrir review síðuna//////////////////
$('#review-form').addClass("hidden");

$('#write-review').click(function(){
  $('#review-form').removeClass("hidden");
  $('#review-form').fadeIn(1000);
});
$('#submit').click(function(){
  
  $('#review-form').addClass("hidden");
  var description = $('#description').val();
  var ratings = $('#ratings').val();
  var bookId = $('#book-id').text();
  $('#review-form').fadeOut(1000); 
  $.post("/book/review", 
  {
    bookId: bookId,
    Description: description,
    Ratings: ratings
  }, 
  function(data, status){
    location.reload();
  })
});
$('#close-review').click( function(){
  $('#review-form').fadeOut(500);

})
////////////////////////////////////////////


/////////Fyrir Cartið///////////////////

$(".remove-from-cart").click( function(){
  var tableRow = $(this).parents("tr"); 
  var bookId = $(this).val();
  console.log(bookId);
    $.post("RemoveFromCart",{ bookId: bookId }, function(data, status){
      console.log(data);
      tableRow.remove();
    })
});

////////////////////////////////////////////

/////////Add-to-cart///////////////////
$(".add").click( function(){
  //var

})
////////////////////////////////////////////

//// eitthvað sem einhver er að gera er að gera ///
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

$('#check-out-button').hover(function(){
var totalCost = $('#total-cost').html();
  if(totalCost === "0 $") {
    $("#check-out-button").attr("disabled", true);
  } else {
    $("#check-out-button").attr("disabled", false);
   }
  });

  var itemCount = 0;
  $('.add').click(function (){
    var value = $(this).val();
    console.log(value);
    itemCount ++;
    //$('#message').hide().html("You clicked on a checkbox.").fadeIn('slow');
    if(itemCount >= 10) {
      $('#itemCount').hide().html(9 + "+").fadeIn('slow').css("display", "inline");
    } else {
      $('#itemCount').hide().html(itemCount).fadeIn('slow').css("display", "inline");
    }
  }); 
  


$(function() {
    $('.dropdown-toggle').dropdown();
   $('.dropdown input, .dropdown label').click(function(e) {
   e.stopPropagation();
    });
  });
/*
  $("#SubmitShipping").click(function(event){
    event.preventDefault();
    $.post('/Account/ChangeShippingDetails', $('firstForm').serialize(), function(data) {
        alert("Yes");
    }).fail(function(data) {
        alert("hi");
    })
  });
  */
});

// Write your JavaScript code.
$(document).ready(function(){

console.log("Javascript up and running");

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


///////////////Fyrir BookDetails síðuna//////////////////

$('#review-form').addClass("hidden");

$('#write-review').click(function(){
  $.post("/book/LoggedInCheck", {}, function(data, status){
    if( data == "RedirectToLogin"){
      window.location.replace("/account/login");
    }
  })
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
    if( data == "RedirectToLogin"){
      window.location.replace("/account/login");
    }
    else{
      location.reload();
    }
  })
});
$('#close-review').click( function(){
  $('#review-form').fadeOut(500);
})


$('#favorite-book').click(function(){
  var bookId = $('#book-id').text();
  $.post("/book/FavoriteBook", { bookId: bookId }, function(data, status){
    if(data == "RedirectToLogin"){
      window.location.replace("/account/login");
    }
  });
});

////////////////////////////////////////////


/////////Fyrir Cartið///////////////////

$(".remove-from-cart").click( function(){
  var tableRow = $(this).parents("tr"); 
  var bookId = $(this).val();
    $.post("RemoveFromCart",{ bookId: bookId }, function(data, status){
      $(tableRow).fadeOut( "slow", function() {
        tableRow.remove()
      });
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

$('.cart-buttons').hover(function(){
var totalCost = $('#total-cost').html();
  if(totalCost === "Total price: 0 $") {
    $("#clear-cart-button").attr('disabled',true);
    $("#check-out-button").attr('disabled',true);
  } else {
    $("#clear-cart-button").attr('disabled',false);
    $("#check-out-button").attr("disabled", false);
   }
  });

  var itemCount = 0;
  $('.add').click(function (){
    var bookId = $(this).val();
    $.post("/Account/AddToCart", { Id: bookId } );
    itemCount ++;
    if(itemCount >= 10) {
      $('#itemCount').hide().html(9 + "+").fadeIn('slow').css("display", "inline");
    } else {
      $('#itemCount').hide().html(itemCount).fadeIn('slow').css("display", "inline");
    }
  });

  $('.add').click(function () {
    //$(this).html('Added to Cart ✔').fadeIn(2000).fadeOut(2000);
    //$(this).html('Add to cart').fadeIn(2000);
  })

  $('#clear-cart-button').click(function() {
    swal({
      title: 'Are you sure?',
      text: "Removing all items from the cart is irreversible!",
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, cancel!',
      confirmButtonClass: 'btn btn-success',
      cancelButtonClass: 'btn btn-danger',
      buttonsStyling: false,
      reverseButtons: true
    }).then((result) => {
      if (result.value) {
        swal(
          'Deleted!',
          'Your cart is now empty.',
          'success'
        )
        $.post("/Account/EmptyCart", function(){
          $("#cart-table tbody").fadeOut("slow", function() {
            $(this).empty();
          })
          $("#total-cost").fadeOut("slow", function() {
            $(this).empty();
            $(this).html("Total price: 0 $").fadeIn('slow');
          })
        });
      } 
    })
  })

  $('.add').click(function() {
    swal(
      'Success!',
      'Book added to cart!',
      'success'
    )  
  })

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

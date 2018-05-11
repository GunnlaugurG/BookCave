// Write your JavaScript code.
$(document).ready(function () {

  console.log("Javascript up and running");

  function printStars(rating) {
    var markup = "";  
    for (i = 0; i < rating - 1; i++) {
        markup += '<img src="/Images/fullStar.png" alt="rating" class="starRatings">'
      }
      if (rating % 1 != 0) {
        markup += '<img src="/Images/halfStar.png" alt="rating" class="starRatings">'
      } else {
        markup += '<img src="/Images/fullStar.png" alt="rating" class="starRatings">'
      }
      return markup;
  }

  //Ajax request for sorting the book list "All Books"
  $("#selectBox").change(function () {
    var sortVal = $(this).val();
    console.log(sortVal);
    var markup = "";
    $.get("/book/SortBy", { value: sortVal }, function (data) {
      $('#book-list').fadeOut(1000, function () {
        $('#book-list').empty();
      });
      $('#book-list').fadeIn(200, function () {

        $.each(data, function (i, j) {
          markup += '<div id="animate-list" class="col-lg-3 col-sm-6 col-md-4" style="display: none;">'
            + '<div class="row"> <div class="col-lg-12 col-sm-12">'
            + '<a href="/book/details/' + j.id + '">'
            + '<img class="Thumb-nail-image" src="' + j.image + '"alt="book-cover" /></a>'
            + '</div> </div> <div class="row"> <div id="book-info" class="col-lg-12 col-sm-12">'
            + '<a href="/book/details/' + j.id + ' class="card-text">' + j.title + '</a> <br/><div class="divider"></div>'
            + '<a href="/author/details/' + j.author.id + '"class=card-text">' + j.author.authorName + '</a> <br/>'
            + printStars(j.rating)
          markup += '<p></a>' + j.cost + ' $</p></div> </div><div class="row">'
            + '<div class="col-lg-12 col-sm-12 img-thumbnail-btn"><a class="btn btn-default center-block" href="/account/addToCart/'
            + j.id + '">Add to cart</a></div> </div><div class="row">'
            + '<div class="col-lg-12 col-sm-4 spacing"></div></div></div>';

          $(markup).appendTo("#book-list").slideDown(1000);
          markup = "";
        });
        ;
      });
    });
  });

  //$.post("account/ChangeName",{firstName: "Stebbi", lastName: "cool" });
  ///////////////Fyrir BookDetails síðuna//////////////////

  $('#review-form').addClass("hidden");

  $('#write-review').click(function () {
    $.post("/book/LoggedInCheck", {}, function (data, status) {
      if (data == "RedirectToLogin") {
        swal({
          title: 'attention',
          text: 'Only logged in users can write a review!'
        })
      }
      else{
        $('#review-form').removeClass("hidden");
        $('#review-form').fadeIn(1000);
      }
    })

  });
  $('#submit').click(function () {
    $.post("/book/LoggedInCheck", function (data, status) {
      if(data == "RedirectToLogin"){
        swal({
          title: 'attention',
          text: 'Only logged in users can write a review!'
        })
      }
      else {
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
          function (data, status) {
            if (data == "RedirectToLogin") {
              window.location.replace("/account/login");
            }
            var markup = "<fieldset>";
            markup += "<legend>" + data + "</legend>";
            markup += description;
            markup += "<br>";
            markup += printStars(ratings);
            markup += "<br>";
            markup += "<br>";
            markup += "<fieldset>";

            console.log(markup);
            $(markup).hide().prependTo("#review-list").slideDown(500);
          })
      }
    })
  });
  $('#close-review').click(function () {
    $('#review-form').fadeOut(500);
  })


  $('#favorite-book').click(function () {
    var bookId = $('#book-id').text();
    $.post("/book/FavoriteBook", { bookId: bookId }, function (data, status) {
      if (data == "RedirectToLogin") {
        swal({
          title: 'attention',
          text: 'Only logged in users can have a favorite book!'
        })
      }
      else {
        swal(
          'Success!',
          'You have chosen your favorite book!',
          'success'
        )
      }
    });
  });

  ////////////////////////////////////////////


  /////////Fyrir Cartið///////////////////

  $(".cart-quantity").change( function(){
    var quantity = $(this).val();
    var price =  $(this).parent().parent()[0].cells[2].innerText;
    var id = $(this).parent().parent()[0].cells[3].firstElementChild.value;
    $(this).parent().parent()[0].cells[4].innerText = (quantity * price).toFixed(2);
    $.post("UpdateCartItemQuantity", { Quantity: quantity , bookId: id })
  })

  $('.cart-quantity').change(function(){
    console.log("hehe");
    $.get("/account/GetTotalCost", function(data){
        $('#total-cost').html("Total price: " + data + " $");
    })  
  })

  $(".remove-from-cart").click(function () {
    var tableRow = $(this).parents("tr");
    var bookId = $(this).val();
    $.post("RemoveFromCart", { bookId: bookId }, function (data, status) {
      $.get("/account/GetTotalCost", function(data){
       
        $('#total-cost').html("Total price: " + data + " $");
      })
      $(tableRow).fadeOut("slow", function () {
        tableRow.remove()
      });
    })
  });



  $("#back-to-top").click(function () {
    $("html, body").animate({ scrollTop: 0 }, 500);
  });

  $(window).scroll(function () {
    if ($(this).scrollTop() > 1000) {
      $('#back-to-top').fadeIn();
    }
    else {
      $('#back-to-top').fadeOut();
    }
  });

  $('.cart-buttons').hover(function () {
    var totalCost = $('#total-cost').html();
    if (totalCost === "Total price: 0 $") {
      $("#clear-cart-button").attr('disabled', true);
      $("#check-out-button").attr('disabled', true);
    } else {
      $("#clear-cart-button").attr('disabled', false);
      $("#check-out-button").attr("disabled", false);
    }
  });

  var itemCount = 0;
  $('.add').click(function () {
    var bookId = $(this).val();
    $.post("/Account/AddToCart", { Id: bookId }, function (data, status) {
      console.log(data);
      if (data == "NotLoggedIn") {
        swal({
          text: 'Only logged in users can add to cart!'
        })
      }
      else {
        swal(
          'Success!',
          'Book added to cart!',
          'success'
        )
      }
    });
    itemCount++;
    if (itemCount >= 10) {
      $('#itemCount').hide().html(9 + "+").fadeIn('slow').css("display", "inline");
    } else {
      $('#itemCount').hide().html(itemCount).fadeIn('slow').css("display", "inline");
    }
  });

  $('.add').click(function () {
    //$(this).html('Added to Cart ✔').fadeIn(2000).fadeOut(2000);
    //$(this).html('Add to cart').fadeIn(2000);
  })

  $('#clear-cart-button').click(function () {
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
        $.post("/Account/EmptyCart", function () {
          $("#cart-table tbody").fadeOut("slow", function () {
            $(this).empty();
          })
          $("#total-cost").fadeOut("slow", function () {
            $(this).empty();
            $(this).html("Total price: 0 $").fadeIn('slow');
          })
        });
      }
    })
  })
////////FOR-THE-WISHLIST////////
$('.remove-from-wishlist').click(function(){
  var bookid = (this).value;
  console.log(bookid);
$.post("RemoveFromWishList",{ "id": bookid }, function(){
  location.reload();
})
});
/////////////////////////////
  $('#add-to-wish-list').click(function () {

    var bookid = $(this).attr("data-book-id");
    $.post("/Account/AddToWishList", { id: bookid }, function (data, status) {
      if (data == "NotLoggedIn") {
        swal({
          title: 'attention',
          text: 'Only logged in users can add to wishlist!'
        })
      }
      else {
        swal(
          'Success!',
          'Book added to wishlist!',
          'success'
        )
      }
    });
  });
  // þarf að kíkja betur á, fer alltaf í display:none þannig að notendanafnið færist til
  $(window).scroll(function () {
    if ($(this).scrollTop() >= 85) {
      $('#wish-list-navbar').fadeIn(1400).css({ "visibility": "visible" });
      $('#cart-navbar').fadeIn(1400).css({ "visibility": "visible" });
    }
    else {
      $('#wish-list-navbar').fadeOut(200).css({ "visibility": "hidden" });
      $('#cart-navbar').fadeOut(200).css({ "visibility": "hidden" });
    }
  });

  $('#complete-order-button').click(function(){
    var adress = $('#adress').attr("data-value");
    var cardHolderName = $('#cardholder-name').attr("data-value");
    console.log(adress);
    console.log(cardHolderName);
    if(adress == "" || cardHolderName == "") {
      swal({
        title: 'attention',
        text: 'Address and Cardholders name can not be empty'
      })
    } else {
      $.get("/Account/Complete", function(){
        document.location.href="/Account/Complete";
      });
    }
  });

  $(function () {
    $('.dropdown-toggle').dropdown();
    $('.dropdown input, .dropdown label').click(function (e) {
      e.stopPropagation();
    });
  });

});

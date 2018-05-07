// Write your JavaScript code.
console.log("Javascript up and running1");


$("#sort-by").change(function(){
    var sortVal = $(this).val();
    $.post("SortBy", { value: sortVal },
    function(data, status){
      console.log(data); 
      var markup = "";
      for( var i = 0; i < data.length; i++){
        markup += '<div id="settings" class="col-lg-3 col-sm-6 col-md-4">';
        markup += '<div class="row">';
        markup += '<div class="col-lg-12 col-sm-12">';
        markup += ' <img class="Thumb-nail-image" src="' + data[i].image + '" alt="book-cover" />';
        markup += '</div>';
        markup += '</div>';
        markup += '<div class="row">';
        markup += '<div id="book-info" class="col-lg-12 col-sm-12">';
        markup += '<a href="details/' + data[i].id + '" class="card-text">' + data[i].title + '</a>';
        markup += '<div class="divider"></div>';
        markup += '<a href="/author/details/' + data[i].author.id + '">' + data[i].author.authorName + '</a>' ;
        markup += '<p>Rating: ' + data[i].rating + '</p>';
        markup += '<p>Price: ' + data[i].cost + ' $</p>';
        markup += '</div>';
        markup += '</div>';
        markup += '<div class="row">';
        markup += '<div class="col-lg-12 col-sm-12 img-thumbnail-btn">';
        markup += '<a class="btn btn-success center-block" href="#">Add to cart</a>';
        markup += '</div>';
        markup += '</div>';
        markup += '<div class="row">';
        markup += '<div class="col-lg-12 col-sm-4 spacing">';
        markup += '</div>';
        markup += '</div>';
        markup += '</div>';
      
      }
      $("#book-list").empty();
      $("#book-list").append(markup);
    })
});
  
$(function() {
    // Setup drop down menu
    $('.dropdown-toggle').dropdown();
   
    // Fix input element click problem
    $('.dropdown input, .dropdown label').click(function(e) {
      e.stopPropagation();
    });
  });


// 1. Test if jQuery is loaded.
if (jQuery) {
  console.log("jQuery is loaded");
}


// 2. Scroll to the top of the page with jQuery.


// 3. Disable right click menu in html page using jquery.
$("html").contextmenu(function () {
  return false;
});

// 4. Disable/enable the form submit button.
// Disable the submit button until the visitor has clicked a check box.
$("ej-4-checkbox").

var categoryName = document.querySelector("#CategoryName")
var categoryUrlInput = document.querySelector("#CategoryUrl")
var categoryUrlButton = document.querySelector("#CategoryUrlButton")

var postTitle = document.querySelector("#PostTitle")
var postUrlInput = document.querySelector("#PostUrl")
var postUrlInputButton = document.querySelector("#PostUrlButton")

if (categoryName != null) {
    categoryName.addEventListener("keyup", function () {
        ConvertStringToUrl(categoryName, categoryUrlInput)
    })
    categoryUrlButton.addEventListener("click", function () {
        ConvertStringToUrl(categoryName, categoryUrlInput)
    })
}
if (postTitle != null) {
    postTitle.addEventListener("keyup", function () {
        ConvertStringToUrl(postTitle, postUrlInput)
    })
    postUrlInputButton.addEventListener("keyup", function () {
        ConvertStringToUrl(postTitle, postUrlInput)
    })
}
function ConvertStringToUrl(get, set) {
    console.log(get.value)
    var value = get.value
        .trim()
        .toLowerCase()
        .replace(/ü/g, 'u')
        .replace(/ı/g, 'i')
        .replace(/ğ/g, 'g')
        .replace(/ş/g, 's')
        .replace(/ö/g, 'o')
        .replace(/ç/g, 'c')
        .replace(/ü/g, 'u')
        .replace(/ /g, '-')
    set.value = value
}
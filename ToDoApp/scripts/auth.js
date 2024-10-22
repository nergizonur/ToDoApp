$(function () {
    let userId = document.cookie;
    if (!userId)
    {
        $(".taskDiv").html(`<div class="alert alert-warning text-center p-4 mt-5">Görev Eklemek İçin Lütfen <a href="/User/Login">Giriş</a> Yapınız</div>`);
    }
});

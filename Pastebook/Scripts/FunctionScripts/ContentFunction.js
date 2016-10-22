function unlikePost(postID) {
    var data = {
        id: postID
    }
    $.ajax({
        url: UnlikePostUrl,
        data: data,
        type: 'GET',
        success: function (data) {
            refresh()
        },
        error: function () {
            alert("Oops. Something went wrong!")
        }
    })
}

function likePost(postID){
    var data = {
        Post_ID: postID,
        Liked_By: currentID
    }
    $.ajax({
        url: LikePostUrl,
        data: data,
        type: 'GET',
        success: function (data) {
            refresh()
        },
        error: function () {
            alert("Oops. Something went wrong!")
        }
    })
}

$('#btnCreatePost').click(function () {
    var data = {
        Poster_ID: currentID,
        Profile_Owner_ID: 2, //change to profile owner ID
        Content: $('#textArea').val()
    }
    $.ajax({
        url: CreatePostUrl,
        data: data,
        type: 'GET',
        success: function (data) {
            clearTextArea(),
            refresh()
        },
        error: function () {
            alert("Oops. Something went wrong!")
        }
    })
})


function clearTextArea() {
    $('#textArea').val('');
}

function refresh() {
    $('#postListPartial').load(PostRefreshUrl)
}


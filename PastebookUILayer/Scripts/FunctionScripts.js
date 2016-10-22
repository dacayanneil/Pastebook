$('#btnCreatePost').click(function () {
    var data = {
        Poster_ID: currentID,
        Profile_Owner_ID: profileOwner, //change to profile owner ID
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

function unlikePost(likeID, postID) {
    var data = {
        id: likeID,
        post_id: postID,
        liked_by: currentID
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

function likePost(postID) {
    var data = {
        post_id: postID,
        liked_by: currentID
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

function likeNotification(receiverID, postID){
    var data = {
        sender_id: currentID,
        receiver_id: receiverID,
        post_id: postID
    }
    $.ajax({
        url: LikeNotificationUrl,
        data: data,
        type: 'GET',
        success: function(){
            refresh()
        },
        error: function(){
                alert("Oops. Something went wrong!")
            }
    })
}

function clearTextArea() {
    $('#textArea').val('');
}

function refresh() {
    $('#postListPartial').load(PostRefreshUrl)
}

function CreateComment(btnVal) {
    var textAreaContent = $('#textarea_'.concat(btnVal.value)).val()
    var data = {
        post_id: btnVal.value,
        poster_id: currentID,
        content: textAreaContent
    }
    $.ajax({
        url: CreateCommentUrl,
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

function getCommentID(receiverID, postID) {
    var data = {
        poster_id: currentID,        
        post_id: postID
    }
    $.ajax({
        url: GetCommentIDUrl,
        data: data,
        type: 'GET',
        success: function (output) {
            commentNotification(postID, receiverID, output),
            refresh()
        },
        error: function () {
            alert("Oops. Something went wrong!")
        }
    })
}

function commentNotification(postID, receiverID, commentID) {
    var data = {
        sender_id: currentID,
        receiver_id: receiverID,
        post_id: postID,
        comment_ID: commentID
    }
    $.ajax({
        url: CommentNotificationUrl,
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

function sendFriendRequest(friendID) {
    var data = {
        user_id: currentID,
        friend_id: friendID
    }
    $.ajax({
        url: SendFriendRequestUrl,
        data: data,
        type: 'GET',
        success: function (output) {
            friendRequestNotification(currentID, friendID),
            refresh()
        },
        error: function () {
            alert("Oops. Something went wrong!")
        }
    })
}

function acceptFriendRequest(ID) {
    var data = {
        ID: ID
    }
    $.ajax({
        url: AcceptFriendRequestUrl,
        data: data,
        type: 'GET',
        success: function (output) {
            refresh()
        },
        error: function () {
            alert("Oops. Something went wrong!")
        }
    })
}

function declineFriendRequest(ID) {
    var data = {
        ID: ID
    }
    $.ajax({
        url: DeclineFriendRequestUrl,
        data: data,
        type: 'GET',
        success: function (output) {
            refresh()
        },
        error: function () {
            alert("Oops. Something went wrong!")
        }
    })
}


function friendRequestNotification(currentID, friendID) {
    var data = {
        sender_id: currentID,
        receiver_id: friendID
    }
    $.ajax({
        url: FriendRequestNotificationUrl,
        data: data,
        type: 'GET',
        success: function (output) {
            refresh()
        },
        error: function () {
            alert("Oops. Something went wrong!")
        }
    })
}

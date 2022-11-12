module.exports = {
  IsAuth: function Check_auth(request, response) {
    if (request.session.is_logined) {
      return true;
    } else {
      return false;
    }
  },
  Status: function authStatus(request, response) {
    var authstatus = '<a href="/auth/login">login</a>';
    if (this.IsAuth(request, response)) {
      authstatus = `${request.session.nickname}|<a href="/auth/logout">logout</a>`;
    }
    return authstatus;
  },
};

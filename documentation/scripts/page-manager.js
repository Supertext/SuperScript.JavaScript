var PageManager = function (win, doc) {

	var self = this,
		projectName = "SuperScript.JavaScript",
		issueUrl = "https://github.com/Supertext/" + projectName + "/issues/new",
		urlSegments = doc.location.pathname.split("/"),
		removeLastSegment = urlSegments.pop(),
		urlDirectory = doc.location.protocol + "//" + doc.location.host + urlSegments.join("/") + "/documentation/",
	
		configureRouting = function() {
			Routing.map("#!/page/:contentName")
					.before(function() {
						$("#content").html("<img src=\"https://assets-cdn.github.com/images/spinners/octocat-spinner-32.gif\" alt=\"loading...\" class=\"center-block\" />");
						$("a.active").removeClass("active");
					})
					.to(function() {
						
							var specificPath = this.params.contentName.value.replace(new RegExp(".", "g"), "/") + ".html",
								loadUrl = urlDirectory + specificPath,
								elmntLink = $("a[href='" + specificPath + "']");
								
							$.ajax({
								dataType: "html",
								type: "GET",
								url: loadUrl,
								success: function (data) {
									$("#content").html(data);
									
									SyntaxHighlighter.highlight();
								},
								error: function (xmlHttpRequest, textStatus, errorThrown) {
									$("#content").html("<p>Sorry, it looks like an error occurred!</p><p>How about letting us know by creating an <a href=\"" + issueUrl + "\" target=\"_blank\">issue</a>?</p>");
								}
							});
							
							if (elmntLink.length > 0) {
								var elmntLi = elmntLink.parent("li");
								elmntLi.addClass("active");
								elmntLi.parents("li.dropdown").addClass("active");
							}
					});
		};

	return {
		"setupRouteHandler": configureRouting
	};
}(window, window.document);


$(function() {
	PageManager.setupRouteHandler();
	Routing.root("#!/page/index");
	Routing.listen();
	
	SyntaxHighlighter.defaults["gutter"] = false;
	SyntaxHighlighter.defaults["toolbar"] = false;
	SyntaxHighlighter.all();
});

resource "aws_appsync_graphql_api" "blog_api" {
  authentication_type = "API_KEY"
  name                = "claudiordgz-blog-${var.env}"
}

output "blog_api_id" {
  value = "${aws_appsync_graphql_api.blog_api.id}"
}

output "blog_api_arn" {
  value = "${aws_appsync_graphql_api.blog_api.arn}"
}

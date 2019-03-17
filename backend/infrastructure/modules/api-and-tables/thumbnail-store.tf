resource "aws_dynamodb_table" "thumbnail_table" {
  name           = "thumbnail-table-${var.env}"
  read_capacity  = 1
  write_capacity = 1
  hash_key       = "id"

  attribute {
    name = "id"
    type = "S"
  }
}

resource "aws_appsync_datasource" "thumbnail_table" {
  api_id = "${aws_appsync_graphql_api.blog_api.id}"
  name   = "${aws_dynamodb_table.thumbnail_table.id}_${var.env}"
  type   = "AMAZON_DYNAMODB"

  dynamodb_config {
    region     = "${var.region}"
    table_name = "${aws_dynamodb_table.thumbnail_table.id}"
  }

  service_role_arn = "${aws_iam_role.claudiordgz_appsync_role.arn}"
}

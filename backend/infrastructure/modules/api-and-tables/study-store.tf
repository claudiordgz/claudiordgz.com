resource "aws_dynamodb_table" "study_table" {
  name           = "study-table-${var.env}"
  read_capacity  = 1
  write_capacity = 1
  hash_key       = "id"

  attribute {
    name = "id"
    type = "S"
  }
}

resource "aws_appsync_datasource" "study_table" {
  api_id = "${aws_appsync_graphql_api.blog_api.id}"
  name   = "${aws_dynamodb_table.study_table.id}_${var.env}"
  type   = "AMAZON_DYNAMODB"

  dynamodb_config {
    region     = "${var.region}"
    table_name = "${aws_dynamodb_table.study_table.id}"
  }

  service_role_arn = "${aws_iam_role.claudiordgz_appsync_role.arn}"
}

resource "aws_dynamodb_table" "study_posts_table" {
  name           = "study-posts-table-${var.env}"
  read_capacity  = 1
  write_capacity = 1
  hash_key       = "id"
  range_key      = "studyId"

  attribute {
    name = "id"
    type = "S"
  }

  attribute {
    name = "studyId"
    type = "S"
  }
}

resource "aws_appsync_datasource" "study_posts_table" {
  api_id = "${aws_appsync_graphql_api.blog_api.id}"
  name   = "${aws_dynamodb_table.study_posts_table.id}_${var.env}"
  type   = "AMAZON_DYNAMODB"

  dynamodb_config {
    region     = "${var.region}"
    table_name = "${aws_dynamodb_table.study_posts_table.id}"
  }

  service_role_arn = "${aws_iam_role.claudiordgz_appsync_role.arn}"
}

resource "aws_iam_role" "claudiordgz_appsync_role" {
  name = "claudiordgz-appsync-role-${var.env}"

  assume_role_policy = <<EOF
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Action": "sts:AssumeRole",
      "Principal": {
        "Service": "appsync.amazonaws.com"
      },
      "Effect": "Allow"
    }
  ]
}
EOF
}

resource "aws_iam_role_policy" "claudiordgz_appsync_role_policy" {
  name = "claudiordgz-appsync-role-policy-${var.env}"
  role = "${aws_iam_role.claudiordgz_appsync_role.id}"

  policy = <<EOF
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Action": [
        "dynamodb:*"
      ],
      "Effect": "Allow",
      "Resource": [
        "${aws_dynamodb_table.blog_posts_table.arn}",
        "${aws_dynamodb_table.feeds_table.arn}",
        "${aws_dynamodb_table.feeds_posts_table.arn}",
        "${aws_dynamodb_table.projects_table.arn}",
        "${aws_dynamodb_table.projects_posts_table.arn}",
        "${aws_dynamodb_table.study_table.arn}",
        "${aws_dynamodb_table.study_posts_table.arn}"
      ]
    }
  ]
}
EOF
}

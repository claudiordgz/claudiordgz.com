module "dev_api" {
  source = "../modules/api-and-tables"
  env    = "dev"
  region = "us-east-1"
}

output "blog_api_id" {
  value = "${module.dev_api.blog_api_id}"
}

output "blog_api_arn" {
  value = "${module.dev_api.blog_api_arn}"
}

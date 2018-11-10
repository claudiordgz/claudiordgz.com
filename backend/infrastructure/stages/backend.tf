provider "aws" {
  profile = "claudio"
  region  = "us-east-1"
}

terraform {
  backend "s3" {
    bucket         = "claudiordgz-terraform-backends"
    dynamodb_table = "claudiordgz-terraform-backend-locks"
    key            = "dev.tfstate"
    region         = "us-east-1"
  }
}

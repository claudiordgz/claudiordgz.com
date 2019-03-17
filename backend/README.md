# Backend Provisioning

The Backend is comprised of multiple rules:

  - The frontend will retrieve data via AWS AppSync. 
  - Backend of will use DynamoDB for scaling.
  - Job to Convert DynamoDB to S3 Parquet file to allow Queries

# Backend Workflow

We will be using multiple environments and we might add more in the future:

  - dev
    Backend settings:
      Bucket: claudiordgz-terraform-state
      Key: dev-${stage}.state
  - prod
    Backend settings:
      Bucket: claudiordgz-terraform-state
      Key: prod-${stage}.state

  
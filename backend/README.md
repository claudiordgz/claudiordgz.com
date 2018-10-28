# Backend Provisioning

The Backend is comprised of multiple rules:

  - The frontend will retrieve data via AWS AppSync. 
  - Backend of will use DynamoDB for scaling.
  - Job to Convert DynamoDB to S3 Parquet file to allow Queries

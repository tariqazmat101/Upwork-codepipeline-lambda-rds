# Aurora-EFS-Lambda Multi-Enviroment CI/CD Pipeline
Documention will soon be added. 

This project outlines a multi-enviroment CI/CD pipeline that builds & deploys .Net containers images into AWS Lambda.

### Pipeline Architecture 
Attach immage to showcase the pipeline working. 

### Files Overview

Below contains a list of all the new files that have been added. 
- application-infrastructure - The file that deploys the enviroment (Lambda,EFS,VPC's,etc) 
- Pipeline.yaml - The configuratation 
- codebuild yaml - used to 

## Deployment Instructions 

There are 2 possible ways to deploy this pipeline. The easiest way 

### Prerequisites



# Upwork-codepipeline-lambda-rds

##VPC Increase limits:
This project deploys 3 VPCS(dev-vpc,test-vpc,prod-vpc) into the region you specify. It may be the case that you hit the VPC regional limit 5. You will need to contact AWS to increase the limit or use a different region altogether. 
https://richardvigilantebooks.com/how-can-i-increase-vpc-limit-in-aws/

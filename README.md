# Aurora-EFS-Lambda Multi-Enviroment CI/CD Pipeline
Documention will soon be added. 

This project outlines a multi-environment CI/CD pipeline that builds & deploys .Net containers images into AWS Lambda.

### Pipeline Architecture 
Attach image to showcase the pipeline working. 

### Files Overview

Below contains a list of files that have been added. 
- **Pipeline.yaml** - Cloudformation template to build the pipeline. ** You have to manually deploy this template **
- **application-infrastructure.yaml** - Cloudformation template that deploys the enviroment (Lambda,EFS,VPC's,etc) 
- **Codebuild.yaml** - Configuration file that specifies the neccesary building steps for codebuild. 


### Prerequisites

First will need a Github-OATH token:
https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token

Follow the instructions in the URL and keep the token safe. You will need it later on. 
Note: Please ensure you are the owner of the repository that is being sourced. 


# Upwork-codepipeline-lambda-rds

##VPC Increase limits:
This project deploys 3 VPCS(dev-vpc,test-vpc,prod-vpc) into the region you specify. It may be the case that you hit the VPC regional limit 5. You will need to contact AWS to increase the limit or use a different region altogether. 
https://richardvigilantebooks.com/how-can-i-increase-vpc-limit-in-aws/

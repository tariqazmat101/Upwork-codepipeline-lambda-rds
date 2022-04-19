# .Net Lambda Multi-Enviroment CI/CD Pipeline


A multi-environment CI/CD pipeline that builds & deploys .Net containers images into AWS Lambda.
![image](ali_pipeline.png)

## Files Overview

Files Added: 
- `Pipeline.yaml` - Cloudformation template to build the pipeline. ** You have to manually deploy this template **
- `Application-infrastructure.yaml` - Cloudformation template that Codepipeline will deploy. 
- `Codebuild.yaml` - Configuration file that specifies the building steps for codebuild. 


## Instructions

Here is a basic summary of what you will need to do: 
1. Create a new Github Oath token. 
2. Fork this Repository. 
3. Manually deploy the `pipeline.yaml` template into your AWS account. 


First will need a Github-OATH token:

https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token

Follow the instructions in the URL and keep the token safe. You will need it later on. 
Note: Please ensure you are the owner of the repository that is being sourced. 


# Important Notes

### VPC Increase limits:
This project deploys 3 VPCS(dev-vpc,test-vpc,prod-vpc) into the region you specify. It may be the case that you hit the max vpcs per region limit (limit = 5) . You will need to contact AWS to increase the limit or use a different region altogether. 
https://richardvigilantebooks.com/how-can-i-increase-vpc-limit-in-aws/

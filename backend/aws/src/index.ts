import { cognito, appsync, iam } from '@pulumi/aws'
import { Config } from '@pulumi/pulumi'
import { Role } from '@pulumi/aws/iam';

const config = new Config('claudiordgz.com')

const globalSettings = {
  environment: config.require('environment')
}

function appSyncRoles (environment: string) {
  /*
  const unauthenticatedPolicyStatementAppsync = {
    Effect: 'Allow',
    Principal: {
      Federated: 'cognito-identity.amazonaws.com'
    },
    Action: 'sts:AssumeRoleWithWebIdentity',
    Condition: [
      {
        StringEquals: {
          'cognito-identity.amazonaws.com:aud': 'us-east-1:12345678-dead-beef-cafe-123456790ab'
        },
        'ForAnyValue:StringLike': {
          'cognito-identity.amazonaws.com:amr': 'authenticated'
        }
      }
    ]
  }
  const unauthenticatedPolicyDocument: iam.PolicyDocument = {
    Version: '2012-10-17',
    Statement: [

    ]
  }

  const unauthenticatedRole = new Role(`${environment}ClaudioRdgzUnauthRole`, {
    name: `claudiordgzUnauthenticatedRole-${environment}`
  })
  */
}

function getResources (environment: string) {
  const appSyncApi = new appsync.GraphQLApi(`${environment}ClaudiordgzAppSyncApi`, {
    authenticationType: 'AWS_IAM',
    name: `claudiordgzAppSyncApi-${environment}`
  })

  const identityPool = new cognito.IdentityPool(`${environment}IdentityPool`, {
    allowUnauthenticatedIdentities: true,
    identityPoolName: `claudiordgzcom_IdentitiyPool_${environment}`
  })
  return {
    appSyncApi,
    identityPool
  }
}

const infrastructure = getResources(globalSettings.environment)

export const identityPoolArn = infrastructure.identityPool.arn
export const appSyncApiArn = infrastructure.appSyncApi.arn

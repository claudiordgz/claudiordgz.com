const program = require('commander')
const { buildSchema } = require('./build/buildSchema')

program
  .version('0.0.1')
  .description('Generates GraphQL Schema for claudiordgz.com')
  .option('-o, --output <file>', 'File to save schema to')
  .parse(process.argv)

if (program.output === undefined) {
  console.error('\n\toutput is required')
  console.log(program.helpInformation())
  process.exit(1)
}

console.log('HELLO')
buildSchema()

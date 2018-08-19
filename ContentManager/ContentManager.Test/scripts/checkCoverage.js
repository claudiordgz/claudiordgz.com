const { readFileSync } = require('fs')

function checkPercentage (percentage) {
  if (percentage < 90) {
    console.error(`Percentage ${percentage}% did not pass threshold of 90%`)
    process.exit(1)
  }
}

function main () {
  const fileContents = readFileSync('../Coverage/coverage.output').toString()
  const mainOutput = fileContents.substr(fileContents.indexOf('+---'), fileContents.lastIndexOf('---+'))
  const pieces = mainOutput.replace(/(\r\n\t|\n|\r\t)/g, '').split('|')
  pieces.forEach(v => {
    if (v.indexOf('%') !== -1) {
      checkPercentage(Number(v.replace(/%/g, '').trim()))
    }
  })
}

main()

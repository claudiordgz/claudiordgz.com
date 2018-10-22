const { readFileSync } = require('fs')

function checkPercentage(percentage) {
  const threshold = 60
  if (percentage < threshold) {
    console.error(`Percentage ${percentage}% did not pass threshold of ${threshold}%`)
    process.exit(1)
  } else {
    console.log(`Percentage ${percentage}% passed threshold of ${threshold}%`)
  }
}

function main () {
  const fileContents = readFileSync('../Coverage/coverage.output').toString()
  if (fileContents.indexOf('Test Run Failed') !== -1) {
    console.error(`Tests failed`)
    process.exit(1)
  }
  const mainOutput = fileContents.substr(fileContents.indexOf('+---'), fileContents.lastIndexOf('---+'))
  const pieces = mainOutput.replace(/(\r\n\t|\n|\r\t)/g, '').split('|')
  let count = 0
  pieces.forEach((v) => {
    if (v.indexOf('%') !== -1 && count < 2) {
      count += 1
      checkPercentage(Number(v.replace(/%/g, '').trim()))
    }
  })
}

main()

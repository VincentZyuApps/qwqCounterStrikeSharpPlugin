import { copyFileSync, existsSync, mkdirSync, readFileSync, rmSync, writeFileSync } from 'node:fs'
import { dirname, join, resolve } from 'node:path'
import { fileURLToPath } from 'node:url'

const packageRoot = resolve(dirname(fileURLToPath(import.meta.url)), '..')
const fontPackage = join(packageRoot, 'node_modules', '@free-fonts', 'lxgw-wenkai')
const target = join(packageRoot, 'docs', 'public', 'lxgw-wenkai')
const sourceCss = readFileSync(join(fontPackage, 'lxgw-wenkai.css'), 'utf8')
const regularFaces = sourceCss.match(/@font-face\s*\{[^}]*font-weight:\s*400;[^}]*\}/g) ?? []
const outputCss = ['/* Generated from @free-fonts/lxgw-wenkai. */', ...regularFaces].join('\n\n')
const fontFiles = [...outputCss.matchAll(/url\(['"]?fonts\/([^'")]+)['"]?\)/g)].map((match) => match[1])

rmSync(target, { recursive: true, force: true })
mkdirSync(join(target, 'fonts'), { recursive: true })

for (const file of fontFiles) {
  const source = join(fontPackage, 'fonts', file)
  if (existsSync(source)) copyFileSync(source, join(target, 'fonts', file))
}

writeFileSync(join(target, 'lxgw-wenkai.css'), outputCss)

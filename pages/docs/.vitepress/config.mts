import { defineConfig } from 'vitepress'

const base = process.env.NODE_ENV === 'production' ? '/qwqCounterStrikeSharpPlugin/' : '/'

export default defineConfig({
  lang: 'zh-CN',
  title: 'VincentZyu233 CS2 私服',
  description: '皮肤、传送、趣味聊天与丢刀玩法的玩家指南。',
  base,
  cleanUrls: true,
  head: [
    ['link', { rel: 'icon', type: 'image/png', href: `${base}favicon.png` }],
    ['link', { rel: 'stylesheet', href: `${base}lxgw-wenkai/lxgw-wenkai.css` }]
  ],
  themeConfig: {
    siteTitle: 'VincentZyu233 CS2 私服',
    nav: [
      { text: '首页', link: '/' },
      { text: '进服指导', link: '/guides/join' },
      { text: 'GitHub', link: 'https://github.com/VincentZyuApps/qwqCounterStrikeSharpPlugin' }
    ],
    outlineTitle: '本页内容',
    returnToTopLabel: '返回顶部',
    darkModeSwitchTitle: '切换外观'
  }
})

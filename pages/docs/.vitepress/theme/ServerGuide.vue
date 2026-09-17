<script setup lang="ts">
import { computed, onBeforeUnmount, onMounted, ref } from 'vue'
import { withBase } from 'vitepress'

const copied = ref(false)
const connectCommand = 'connect laoke.vincentzyu233.cn:60829'
const commandGroups = [
  {
    id: 'skins',
    kicker: 'ASTRA SKINS',
    title: '饰品与外观',
    entries: [
      ['!ws', '打开主皮肤菜单。'],
      ['!ws <搜索内容>', '搜索武器皮肤、刀具、手套、探员与音乐盒。'],
      ['!knife / !gloves / !agents', '分别进入刀具、手套与探员目录。'],
      ['!seed / !wear', '设置手持武器或手套的图案模板与磨损度。'],
      ['!nametag / !stattrak', '设置名称标签，或管理手持武器的 StatTrak。']
    ]
  },
  {
    id: 'tpa',
    kicker: 'LUA TPA',
    title: '玩家传送',
    entries: [
      ['!tpalist', '列出在线玩家的 userid 与 slot。'],
      ['!tpa <查询>', '请求传送到指定玩家身边。'],
      ['!tpahere <查询>', '邀请指定玩家传送到自己身边。'],
      ['!tpaid / !tpaslot / !tpaname', '按 userid、slot 或名字片段精确指定匹配方式。'],
      ['!tpaccept / !tpdeny / !tpcancel', '接受、拒绝或取消传送请求。']
    ]
  },
  {
    id: 'fun',
    kicker: 'CHAT & KNIFE',
    title: '聊天与丢刀',
    entries: [
      ['awa', '发送后收到紫色 awa_from_lua! 回应。'],
      ['qwq', '发送后收到绿色 qwq! 回应。'],
      ['!drop / !takeknife', '将已装备的刀分享给存活的同队队友。'],
      ['每回合一次', '丢刀玩法每名玩家每回合只能使用一次。']
    ]
  }
]

const features = [
  {
    icon: '💬',
    title: 'qwq 进服播报',
    description: '真人玩家进服与离服会在聊天区广播；输入 qwq 可收到绿色回应。',
    href: 'https://github.com/VincentZyuApps/qwqCounterStrikeSharpPlugin'
  },
  {
    icon: '🎨',
    title: '换皮肤',
    description: '用 !ws 浏览武器、刀具、手套与探员，并将选择持久保存。',
    href: 'https://github.com/VincentZyu233/AstraSkins'
  },
  {
    icon: '🔪',
    title: '丢刀给队友',
    description: '装备刀后输入 !drop 或 !takeknife，与存活的同队玩家分享。',
    href: 'https://github.com/VincentZyu233/CS2DropKnife'
  },
  {
    icon: '🟣',
    title: 'awa Lua 插件',
    description: '发送 awa 获得紫色回应，也会在真人进服与离服时播报。',
    href: 'https://github.com/VincentZyu233/lua2csmod/blob/main/examples/awa.lua'
  },
  {
    icon: '🧭',
    title: 'TPA 玩家传送',
    description: '查找玩家、发起传送申请、接受或拒绝，减少集合等待。',
    href: 'https://github.com/VincentZyu233/lua2csmod'
  }
]

const carouselSlides = [
  {
    src: '/images/minecraft-cache-diamond-sword.png',
    alt: 'Minecraft Cache 地图中手持钻石剑外观的 CS2 游戏画面'
  },
  {
    src: '/images/minecraft-cache-huntsman-axe.png',
    alt: 'Minecraft Cache 地图中手持猎杀者匕首钻石斧外观的 CS2 游戏画面'
  },
  {
    src: '/images/minecraft-cache-navy-doppler.png',
    alt: 'Minecraft Cache 地图中手持深蓝多普勒锯齿爪子刀外观的 CS2 游戏画面'
  },
  {
    src: '/images/minecraft-cache-m9-bayonet.png',
    alt: 'Minecraft Cache 地图中手持 M9 刺刀外观的 CS2 游戏画面'
  }
]

const axeImage = computed(() => withBase('/images/minecraft-cache-huntsman-axe.png'))
const skinImage = computed(() => withBase('/images/minecraft-cache-navy-doppler.png'))
const m9Image = computed(() => withBase('/images/minecraft-cache-m9-bayonet.png'))
const joinGuideLink = computed(() => withBase('/guides/join'))
const activeSlide = ref(0)
const slideTransition = ref<'slide-right' | 'slide-left'>('slide-right')
let carouselTimer: ReturnType<typeof setInterval> | undefined

function stopCarousel() {
  if (carouselTimer !== undefined) {
    clearInterval(carouselTimer)
    carouselTimer = undefined
  }
}

function moveSlide(direction: number) {
  const lastSlide = carouselSlides.length - 1

  if (direction > 0) {
    if (activeSlide.value === lastSlide) {
      // 第一张从左侧进入，避免末尾继续向右时出现空白。
      slideTransition.value = 'slide-left'
      activeSlide.value = 0
      return
    }

    slideTransition.value = 'slide-right'
    activeSlide.value += 1
    return
  }

  if (activeSlide.value === 0) {
    slideTransition.value = 'slide-right'
    activeSlide.value = lastSlide
    return
  }

  slideTransition.value = 'slide-left'
  activeSlide.value -= 1
}

function startCarousel() {
  stopCarousel()
  carouselTimer = setInterval(() => moveSlide(1), 6000)
}

function selectSlide(direction: number) {
  moveSlide(direction)
  startCarousel()
}

onMounted(startCarousel)
onBeforeUnmount(stopCarousel)

async function copyConnectCommand() {
  try {
    await navigator.clipboard.writeText(connectCommand)
    copied.value = true
    window.setTimeout(() => { copied.value = false }, 1800)
  } catch {
    copied.value = false
  }
}
</script>

<template>
  <div class="site-shell">
    <header class="site-header">
      <a class="wordmark" href="#top" aria-label="返回页面顶部">VincentZyu的<span>CS2私服</span></a>
      <nav aria-label="页面导航">
        <a href="#join">进服</a>
        <a href="#commands">指令</a>
        <a href="#tips">提示</a>
        <a href="https://github.com/VincentZyuApps/qwqCounterStrikeSharpPlugin" target="_blank" rel="noreferrer">GitHub</a>
      </nav>
    </header>

    <main id="top">
      <section class="hero" aria-labelledby="page-title" @mouseenter="stopCarousel" @mouseleave="startCarousel">
        <div class="hero-images" aria-live="polite">
          <Transition :name="slideTransition">
            <img :key="carouselSlides[activeSlide].src" class="hero-image" :src="withBase(carouselSlides[activeSlide].src)" :alt="carouselSlides[activeSlide].alt">
          </Transition>
        </div>
        <div class="hero-shade"></div>
        <button class="carousel-control carousel-control-previous" type="button" title="上一张图片" aria-label="上一张图片" @click="selectSlide(-1)"><span aria-hidden="true">←</span></button>
        <button class="carousel-control carousel-control-next" type="button" title="下一张图片" aria-label="下一张图片" @click="selectSlide(1)"><span aria-hidden="true">→</span></button>
        <div class="hero-content">
          <p class="eyebrow">COUNTER-STRIKE 2 COMMUNITY SERVER</p>
          <h1 id="page-title">VincentZyu233<br>CS2 私服</h1>
          <p class="hero-summary">Minecraft Cache 创意工坊地图，带皮肤、传送、趣味聊天和丢刀玩法。</p>
          <div class="hero-actions" aria-label="快速操作">
            <a class="hero-action hero-action-primary" href="#commands">玩法介绍 <span aria-hidden="true">↓</span></a>
            <a class="hero-action" href="https://qm.qq.com/q/9IEB9EOYdG" target="_blank" rel="noreferrer">加入 3水_awa 群 <span aria-hidden="true">↗</span></a>
            <button class="hero-action" type="button" @click="copyConnectCommand">{{ copied ? '进服指令已复制' : '复制进服指令' }}</button>
          </div>
          <p class="group-request">想更换地图、推荐创意工坊地图或提出轮换需求？想增加新玩法、寻找现成插件或编写新插件？欢迎在群里 <strong>@ VincentZyu</strong> 提需求。</p>
        </div>
      </section>

      <section class="features-band" aria-labelledby="features-title">
        <div class="section-heading">
          <p class="section-label">SERVER FEATURES</p>
          <h2 id="features-title">进服就能玩的功能</h2>
        </div>
        <div class="feature-grid">
          <article v-for="feature in features" :key="feature.title" class="feature-item">
            <span class="feature-icon" aria-hidden="true">{{ feature.icon }}</span>
            <h3><a :href="feature.href" target="_blank" rel="noreferrer">{{ feature.title }}</a></h3>
            <p>{{ feature.description }}</p>
          </article>
        </div>
      </section>

      <section id="join" class="join-band" aria-labelledby="join-title">
        <div>
          <p class="section-label">QUICK START</p>
          <h2 id="join-title">进服开始玩</h2>
          <p>在 CS2 控制台粘贴以下指令后回车。还没有启用控制台？查看<a :href="joinGuideLink">进服指导</a>。</p>
        </div>
        <div class="command-copy">
          <code>{{ connectCommand }}</code>
          <button type="button" @click="copyConnectCommand">{{ copied ? '已复制' : '复制' }}</button>
        </div>
      </section>

      <section class="map-band" aria-labelledby="map-title">
        <div>
          <p class="section-label">DEFAULT MAP</p>
          <h2 id="map-title">Minecraft Cache</h2>
          <p>服务器默认使用创意工坊地图 <code>de_minecraft_cache_new</code>。熟悉的 Cache 对枪路线被改造成像素方块场景，正好适合试试你的刀、手套和武器外观。</p>
        </div>
        <img :src="axeImage" alt="Minecraft Cache 地图中手持猎杀者匕首钻石斧外观的 CS2 游戏画面">
      </section>

      <section id="commands" class="commands-section" aria-labelledby="commands-title">
        <div class="section-heading">
          <p class="section-label">PLAYER COMMANDS</p>
          <h2 id="commands-title">常用指令</h2>
          <p>聊天框输入。带参数的命令用实际内容替换尖括号部分。</p>
        </div>
        <div class="command-groups">
          <article v-for="group in commandGroups" :id="group.id" :key="group.id" class="command-group">
            <p class="group-kicker">{{ group.kicker }}</p>
            <h3>{{ group.title }}</h3>
            <dl>
              <div v-for="entry in group.entries" :key="entry[0]" class="command-row">
                <dt><code>{{ entry[0] }}</code></dt>
                <dd>{{ entry[1] }}</dd>
              </div>
            </dl>
          </article>
        </div>
        <figure class="skins-preview">
          <img :src="skinImage" alt="Minecraft Cache 地图中手持深蓝多普勒锯齿爪子刀外观的 CS2 游戏画面">
          <figcaption>皮肤选择会持久保存，重连或换图后仍可使用。</figcaption>
        </figure>
      </section>

      <section id="tips" class="tips-band" aria-labelledby="tips-title">
        <p class="section-label">HOW IT WORKS</p>
        <h2 id="tips-title">几个小提示</h2>
        <div class="tips-grid">
          <p><strong>皮肤菜单</strong>：使用 <kbd>W</kbd>/<kbd>S</kbd> 浏览，<kbd>E</kbd> 选择，<kbd>Shift</kbd> 返回，<kbd>R</kbd> 关闭。</p>
          <p><strong>TPA 查询</strong>：纯数字会按 slot、userid 或 SteamID64 匹配；名字按忽略大小写的普通片段匹配，重名时请补全。</p>
          <p><strong>传送条件</strong>：双方需要在线且存活；请求 30 秒后过期，可随时用 <code>!tpcancel</code> 取消。</p>
        </div>
        <figure class="play-preview">
          <img :src="m9Image" alt="Minecraft Cache 地图中手持 M9 刺刀外观的 CS2 游戏画面">
          <figcaption>进服后，从一局像素 Cache 对枪开始。</figcaption>
        </figure>
      </section>
    </main>

    <footer>
      <span>VincentZyu233 CS2 私服</span>
      <a href="https://github.com/VincentZyuApps/qwqCounterStrikeSharpPlugin" target="_blank" rel="noreferrer">插件与站点源码</a>
    </footer>
  </div>
</template>

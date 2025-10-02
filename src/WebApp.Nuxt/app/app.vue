<template>
  <div>
    <NuxtRouteAnnouncer />
    <NuxtWelcome />
    <div>
      <span>{{ $t('welcome') }}</span>
    </div>
    <div>
      <span>a second attempt with script func:</span>
      <span>{{ t('welcome') }}</span>
    </div>
  </div>
  <div>
    <Button variant="secondary">Button</Button>
  </div>
</template>

<script setup lang="ts">
const { t } = useI18n();
</script>

import React from 'react'
import LoremText from './LoremText';
import NavigationArea from './NavigationArea';

export default function Home() {

  const navigationLinks = [
    { path: '/second', text: 'Second Page' },
    { path: '/third', text: 'Third Page' },
    { path: '/logs', text: 'Logs Page' },
    { path: '/logs/all', text: 'All Logs' },
  ]

  return (
    <div>
      <h1>Home page</h1>
      <NavigationArea links={navigationLinks}></NavigationArea>
      <LoremText></LoremText>
    </div>
  )
}
﻿using SoftTech.Wui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.XPath;
using System.Xml.Linq;
using MetaTech.Library;

namespace SoftTech.WebConsole
{
  public class Part2
  {
    public static SoftTech.Wui.HtmlResult<HElement> HView(object _state, JsonData[] jsons, HContext context)
    {
      var state = _state.As<MainState>() ?? new MainState();

      foreach (var json in jsons.Else_Empty())
      {
        //var account = MemoryDatabase.World.Accounts.FirstOrDefault(_account => _account.Name == "darkgray");

        switch (json.JPath("data", "command").ToString_Fair())
        {
          default:
            //state = new MyLibState(new[] { new Message(json.ToString_Fair()) }.Concat(state.Messages).Take(10).ToArray());
            break;
        }
      }
     

      var page = Page(state, context);
      return new SoftTech.Wui.HtmlResult<HElement>
      {
        Html = page,
        State = state,
      };
    }

   
    private static HElement Page(MainState state, HContext context)
    {

      var page = h.Div
      (
        h.Div(DateTime.UtcNow),
        h.Div(DateTime.UtcNow.Second / 2 % 2 == 0),
        h.Input(h.type("button"), h.onclick(";"), h.value("update")),
        h.Input(h.type("button"), h.onclick(";;sync.server_element_event(this, e)"), h.value("manual update"), new hdata{{"command", "test"}}),
        h.Div(1, h.Attribute("js-init", "$(this).css('color', 'green')")),
        h.Div(DateTime.UtcNow.Second / 2 % 2 == 0 ? new HRaw("12<b>a</b>q"): null),
        h.Div
        (
          HWebSynchronizeHandler.Updates(context.HttpContext)
           .Select(update => h.Div(string.Format("{0}({1}): {2}", update.Handler, update.Cycle, update.Elapsed)))        
        )
      );
      return page;
    }



    static readonly HBuilder h = null;

  }


}
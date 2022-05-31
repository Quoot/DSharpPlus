// This file is part of the DSharpPlus project.
//
// Copyright (c) 2015 Mike Santiago
// Copyright (c) 2016-2022 DSharpPlus Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using DSharpPlus.Core.Attributes;
using DSharpPlus.Core.Enums;
using Newtonsoft.Json;

namespace DSharpPlus.Core.RestEntities
{
    [DiscordGatewayPayload("MESSAGE_CREATE", "MESSAGE_UPDATE")]
    public sealed record DiscordMessage
    {
        /// <summary>
        /// The id of the message.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public DiscordSnowflake Id { get; init; } = null!;

        /// <summary>
        /// The id of the channel the message was sent in.
        /// </summary>
        [JsonProperty("channel_id", NullValueHandling = NullValueHandling.Ignore)]
        public DiscordSnowflake ChannelId { get; init; } = null!;

        /// <summary>
        /// The id of the guild the message was sent in.
        /// </summary>
        /// <remarks>
        /// For MESSAGE_CREATE and MESSAGE_UPDATE events, the message object may not contain a guild_id or member field since the events are sent directly to the receiving user and the bot who sent the message, rather than being sent through the guild like non-ephemeral messages.
        /// </remarks>
        [JsonProperty("guild_id", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordSnowflake> GuildId { get; init; }

        /// <summary>
        /// The author of this message (not guaranteed to be a valid user, see below).
        /// </summary>
        /// <remarks>
        /// The author object follows the structure of the user object, but is only a valid user in the case where the message is generated by a user or bot user. If the message is generated by a webhook, the author object corresponds to the webhook's id, username, and avatar. You can tell if a message is generated by a webhook by checking the value of <see cref="WebhookId"/>.
        /// </remarks>
        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public DiscordUser Author { get; init; } = null!;

        /// <summary>
        ///The member properties for this message's author.
        /// </summary>
        /// <remarks>
        /// The member object exists in MESSAGE_CREATE and MESSAGE_UPDATE events from text-based guild channels, provided that the message isn't ephemeral and the author of the message is not a webhook. This allows bots to obtain real-time member data without requiring bots to store member state in memory.
        /// </remarks>
        [JsonProperty("member", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordGuildMember> Member { get; init; }

        /// <summary>
        /// The contents of the message.
        /// </summary>
        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; init; } = null!;

        /// <summary>
        /// When this message was sent.
        /// </summary>
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset Timestamp { get; init; }

        /// <summary>
        /// When this message was edited (or <see langword="null"/> if never).
        /// </summary>
        [JsonProperty("edited_timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EditedTimestamp { get; init; }

        /// <summary>
        /// Whether this was a TTS message.
        /// </summary>
        [JsonProperty("tts", NullValueHandling = NullValueHandling.Ignore)]
        public bool TTS { get; init; }

        /// <summary>
        /// Whether this message mentions everyone.
        /// </summary>
        [JsonProperty("mention_everyone", NullValueHandling = NullValueHandling.Ignore)]
        public bool MentionEveryone { get; init; }

        /// <summary>
        /// The users specifically mentioned in the message with an additional partial member field.
        /// </summary>
        [JsonProperty("mentions", NullValueHandling = NullValueHandling.Ignore)]
        public DiscordUser[] Mentions { get; init; } = Array.Empty<DiscordUser>();

        /// <summary>
        /// The roles specifically mentioned in this message.
        /// </summary>
        [JsonProperty("mention_roles", NullValueHandling = NullValueHandling.Ignore)]
        public DiscordRole[] MentionRoles { get; init; } = Array.Empty<DiscordRole>();

        /// <summary>
        /// The channels specifically mentioned in this message.
        /// </summary>
        [JsonProperty("mention_channels", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordChannel[]> MentionChannels { get; init; }

        /// <summary>
        /// The attached files.
        /// </summary>
        [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
        public DiscordAttachment[] Attachments { get; init; } = Array.Empty<DiscordAttachment>();

        /// <summary>
        /// The embedded content.
        /// </summary>
        [JsonProperty("embeds", NullValueHandling = NullValueHandling.Ignore)]
        public DiscordEmbed[] Embeds { get; init; } = Array.Empty<DiscordEmbed>();

        /// <summary>
        /// The reactions to the message.
        /// </summary>
        [JsonProperty("reactions", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordReaction[]> Reactions { get; init; }

        /// <summary>
        /// Used for validating a message was sent.
        /// </summary>
        /// <remarks>
        /// Can be an integer or string.
        /// </remarks>
        [JsonProperty("nonce", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<object> Nonce { get; init; }

        /// <summary>
        /// Whether this message is pinned.
        /// </summary>
        [JsonProperty("pinned", NullValueHandling = NullValueHandling.Ignore)]
        public bool Pinned { get; init; }

        /// <summary>
        /// If the message is generated by a webhook, this is the webhook's id.
        /// </summary>
        [JsonProperty("webhook_id", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordSnowflake> WebhookId { get; init; }

        /// <summary>
        /// The type of message.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public DiscordMessageType Type { get; init; }

        /// <summary>
        /// Sent with Rich Presence-related chat embeds.
        /// </summary>
        [JsonProperty("activity", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordMessageActivity> Activity { get; init; }

        /// <summary>
        /// Sent with Rich Presence-related chat embeds.
        /// </summary>
        [JsonProperty("application", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordApplication> Application { get; init; }

        /// <summary>
        /// If the message is an Interaction or application-owned webhook, this is the id of the application.
        /// </summary>
        [JsonProperty("application_id", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordSnowflake> ApplicationId { get; init; }

        /// <summary>
        /// The data showing the source of a crosspost, channel follow add, pin, or reply message.
        /// </summary>
        [JsonProperty("message_reference", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordMessageReference> MessageReference { get; init; }

        /// <summary>
        /// The message flags combined as a bitfield.
        /// </summary>
        [JsonProperty("flags", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordMessageFlags> Flags { get; init; }

        /// <summary>
        /// The message associated with <see cref="MessageReference"/>.
        /// </summary>
        [JsonProperty("referenced_message", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordMessage?> ReferencedMessage { get; init; }

        /// <summary>
        /// Sent if the message is a response to an Interaction.
        /// </summary>
        [JsonProperty("interaction", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordMessageInteraction> Interaction { get; init; }

        /// <summary>
        /// The thread that was started from this message. Includes thread member object.
        /// </summary>
        [JsonProperty("thread", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordChannel> Thread { get; init; }

        /// <summary>
        /// Sent if the message contains components like buttons, action rows, or other interactive components.
        /// </summary>
        [JsonProperty("components", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<IDiscordMessageComponent[]> Components { get; init; }

        /// <summary>
        /// Sent if the message contains stickers.
        /// </summary>
        [JsonProperty("sticker_items", NullValueHandling = NullValueHandling.Ignore)]
        public Optional<DiscordMessageStickerItem[]> StickerItems { get; init; }

        /// <summary>
        /// Deprecated. The stickers sent with the message
        /// </summary>
        [JsonProperty("stickers", NullValueHandling = NullValueHandling.Ignore)]
        [Obsolete("This property is deprecated and will be removed in a future version. Use StickerItems instead.")]
        public Optional<DiscordSticker[]> Stickers { get; init; }
    }
}
